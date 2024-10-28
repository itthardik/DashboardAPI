
using Dashboard.Models.DTOs.Request;
using Dashboard.Models;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Dashboard.Services.Interfaces;
using Dashboard.Repository.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Hangfire;
using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
//todo stop this live orders
namespace Dashboard.Services
{
    /// <summary>
    /// Order Service
    /// </summary>
    public class OrderService( MqttService mqttService, IOrderRepository orderRepository, IAlertRepository alertRepository, IBackgroundJobClient backgroundJobClient, IProductRepository productRepository) :IOrderService
    {
        private readonly MqttService _mqttService = mqttService;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IAlertRepository _alertRepository = alertRepository;
        private readonly IBackgroundJobClient _backgroundJobClient = backgroundJobClient;

        /// <summary>
        /// Place new Order
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task PlaceOrder(List<RequestOrderItem> orderItems)
        {
            var newOrder = _orderRepository.AddEmptyOrder(3);

            foreach (var i in orderItems)
            {
                var product = _productRepository.GetProductById(i.ProductId)[0];

                if (product.CurrentStock - i.Quantity < 0)
                    throw new CustomException($"No Stock of product ( ID:{i.ProductId} )", 404);
                else
                {
                    product.CurrentStock -= i.Quantity;
                    product.UpdatedAt = DateTime.UtcNow;
                    if (product.CurrentStock <= product.ReorderPoint)
                    {
                        var alert = _alertRepository.GetAlertByProductId(i.ProductId);

                        if (alert.IsNullOrEmpty())
                        {
                            alert.Add(new() { AlertLevel = 1, ProductId = product.Id });
                            _alertRepository.AddAlert(alert[0]);
                        }
                        else
                        {
                            if (alert[0].Status == "Pending")
                                alert[0].AlertLevel++;
                            else
                            {
                                alert[0].Status = "Pending";
                                alert[0].AlertLevel = 1;
                            }
                            alert[0].NotifiedAt = DateTime.UtcNow;
                            _alertRepository.Save();
                        }
                        await _mqttService.PublishAsync("inventory/notificationAlert", JsonConvert.SerializeObject(alert[0], new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                    }
                }
                var orderDiscount = (new Random().Next(0, 30) / 100) * product.SellingPrice;

                OrderItem item = new()
                {
                    ProductId = i.ProductId,
                    OrderId = newOrder.Id,
                    Quantity = i.Quantity,
                    Price = product.SellingPrice * i.Quantity,
                    Discount = orderDiscount * i.Quantity,
                    Status = "Pending"
                };
                newOrder.TotalPrice += item.Price - (decimal)item.Discount;
                _orderRepository.AddOrderItem(item);

                await _mqttService.PublishAsync("sales/salesByCategory", JsonConvert.SerializeObject(new { product.CategoryId, i.Quantity }));
            }

            await _mqttService.PublishAsync("inventory/orderItems", JsonConvert.SerializeObject(orderItems));
        }

        /// <summary>
        /// Get Live Orders from Excel
        /// </summary>
        public void LiveOrders(string fileName)
        {
            string excelFilePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            _backgroundJobClient.Enqueue<BackgroundJobService>(service =>
                service.ProcessExcelAndPlaceOrders(excelFilePath));
        }
    }
}
