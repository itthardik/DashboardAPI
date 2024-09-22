using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Models.DTOs.Request;
using Dashboard.Repository.Interfaces;
using Dashboard.Services;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Dashboard.Repository
{
    public class OrderRepository(ApiContext context, MqttService mqttService) : IOrderRepository
    {
        private readonly ApiContext _context= context;
        private readonly MqttService _mqttService = mqttService;
        public async Task<JsonResult> PlaceOrder(List<RequestOrderItem> orderItems)
        {
            Order newOrder = new (){UserId=3,TotalPrice=0, Status = "Pending"};
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            foreach (var i in orderItems)
            {

                var product = _context.Products.Find(i.ProductId) ?? throw new CustomException($"No product ( ID:{i.ProductId} ) found", 404);

                if (product.CurrentStock - i.Quantity < 0)
                    throw new CustomException($"No Stock of product ( ID:{i.ProductId} )", 404);
                else
                {
                    product.CurrentStock -= i.Quantity;
                    product.UpdatedAt = DateTime.UtcNow;
                    if (product.CurrentStock <= product.ReorderPoint)
                    {
                        var alert = _context.Alerts.Where((i) => i.ProductId == product.Id).ToList();

                        if (alert.IsNullOrEmpty())
                        {
                            alert.Add( new() { AlertLevel = 1, ProductId = product.Id });
                            _context.Alerts.Add(alert[0]);
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
                        }
                        _context.SaveChanges();
                        await _mqttService.PublishAsync("inventory/notificationAlert", JsonConvert.SerializeObject(alert[0],new JsonSerializerSettings (){ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
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
                newOrder.TotalPrice += item.Price;
                _context.OrderItems.Add(item);
                _context.SaveChanges();
            }

            await _mqttService.PublishAsync("inventory/orderItems", JsonConvert.SerializeObject(orderItems));

            return new JsonResult("Order Placed Successfully") { StatusCode=200};
        }
    }
}
