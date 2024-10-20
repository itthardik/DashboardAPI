using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Models.DTOs.Request;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using System.Text.Json;
using Dashboard.Repository.Interfaces;
using Dashboard.Services.Interfaces;
using Dashboard.Models.DTOs.Response;
using Microsoft.IdentityModel.Tokens;

namespace Dashboard.Services
{
    /// <summary>
    /// Inventory Service
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="alertRepository"></param>
    /// <param name="mqttService"></param>
    /// <param name="productRepository"></param>
    public class InventoryService(IUserRepository userRepository, IAlertRepository alertRepository, MqttService mqttService, IProductRepository productRepository) : IInventoryService
    {
        private readonly IAlertRepository _alertRepository = alertRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly MqttService _mqttService = mqttService;

        /// <summary>
        /// Get Inventory By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filterKey"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public PaginatedResponse<Product> GetInventoryByPagination(int pageNumber, int pageSize, string filterKey)
        {
            var sortedProducts = _productRepository.GetSortedProductsByFilterKey(filterKey);

            var maxPages = (int)Math.Ceiling((decimal)(sortedProducts.Count()) / pageSize);

            var productsByPagination = sortedProducts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new() { MaxPages = maxPages, Data = [.. productsByPagination] };
        }

        /// <summary>
        /// Add Inventory By Product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="stockRequire"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<Product> AddInventoryByProductId(int productId, int stockRequire, string token)
        {
            //Update Inventory
            var product = _productRepository.GetProductIncludingSupplierById(productId);
            product.CurrentStock += stockRequire;
            product.UpdatedAt = DateTime.Now;
            _productRepository.Save();

            //Get username from token
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var username = jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("name"))?.Value;
            if (string.IsNullOrEmpty(username))
                throw new CustomException("Username not found in token", 404);

            //Get user
            var user = _userRepository.GetUserByUserName(username);

            //Send restock Mail
            new SMTPService().SendInventoryRequest(product.Supplier, product, stockRequire, user);

            //update inventory mail
            await _mqttService.PublishAsync("inventory/orderItems", JsonConvert.SerializeObject(
                    new List<RequestOrderItem>() {
                        new(){ ProductId=productId, Quantity = -1*stockRequire }
                    }
                ));

            // get alert 
            var alert = _alertRepository.GetAlertByProductId(productId);

            if (!alert.IsNullOrEmpty() && alert[0].Status == "Pending")
            {
                if (product.CurrentStock >= product.ReorderPoint)
                    alert[0].Status = "Resolved";

                alert[0].NotifiedAt = DateTime.Now;

                _alertRepository.Save();

                // send alert notification
                await _mqttService.PublishAsync("inventory/notificationAlert", JsonConvert.SerializeObject(alert[0], new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }

            return product;
        }
    }
}
