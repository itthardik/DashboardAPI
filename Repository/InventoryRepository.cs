using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Repository.Interfaces;
using Dashboard.Services;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using System.Text.Json;
using Dashboard.Models.DTOs.Request;

namespace Dashboard.Repository
{
    /// <summary>
    /// Inventory Repo
    /// </summary>
    /// <param name="apiContext"></param>
    /// <param name="mqttService"></param>
    public class InventoryRepository(ApiContext apiContext, MqttService mqttService) : IInventoryRepository
    {
        private readonly ApiContext _context = apiContext;
        private readonly MqttService _mqttService = mqttService;

        /// <summary>
        /// Get Inventory By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filterKey"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public JsonResult GetInventoryByPagination(int pageNumber, int pageSize, string filterKey) {
            var allProducts = _context.Products;
            if (allProducts.IsNullOrEmpty())
                throw new CustomException("No Inventory found", 404);

            IQueryable<Product> sortedProducts;

            if(filterKey == "lowToHighStock")
                sortedProducts = allProducts.OrderBy(p => (p.CurrentStock - p.ReorderPoint));
            else if (filterKey == "highToLowStock")
                sortedProducts = allProducts.OrderBy(p => (p.ReorderPoint - p.CurrentStock));
            else
                sortedProducts = allProducts.OrderBy(p => p.Id);

            var maxPages = (int)Math.Ceiling((decimal)(sortedProducts.Count()) / pageSize);

            var productsByPagination = sortedProducts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new JsonResult(new { maxPages, data = productsByPagination.ToList() }) { StatusCode = 200 };
        }

        /// <summary>
        /// Add Inventory By Product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="stockRequire"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<JsonResult> AddInventoryByProductId(int productId, int stockRequire, string token)
        {
            var allProduct = _context.Products.Where(p => p.Id == productId).Include(p => p.Supplier);
            if (allProduct.IsNullOrEmpty())
                throw new CustomException("No Product with this ID", 404);

            var product = allProduct.First();

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var username = jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("name"))?.Value;
            if (string.IsNullOrEmpty(username))
                throw new CustomException("Username not found in token", 404);
            

            var user = _context.Users.Where( u=>u.Username == username);
            if (user.IsNullOrEmpty())
                throw new CustomException("No User found with this username", 404);

            new SMTPService().SendInventoryRequest(product.Supplier,product, stockRequire,user.First());

            product.CurrentStock += stockRequire;
            product.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            await _mqttService.PublishAsync("inventory/orderItems", JsonConvert.SerializeObject(
                    new List<RequestOrderItem>() {
                        new(){ ProductId=productId, Quantity = -1*stockRequire } 
                    }
                ));

            var alert = _context.Alerts.Where(alert => alert.ProductId == productId).ToList();
            if (!alert.IsNullOrEmpty())
            {
                if(product.CurrentStock >= product.ReorderPoint)
                    alert[0].Status = "Resolved";
                alert[0].NotifiedAt = DateTime.Now;
                _context.SaveChanges();
                await _mqttService.PublishAsync("inventory/notificationAlert", JsonConvert.SerializeObject(alert[0], new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }

            return new JsonResult(new { data = product }, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            }) { StatusCode = 200 };
        }
    }
}
