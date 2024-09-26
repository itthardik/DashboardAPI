using ClosedXML.Excel;
using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Models.DTOs.Request;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Dashboard.Services
{
    public class BackgroundJobService(ApiContext context, MqttService mqttService, IOrderRepository orderRepository)
    {
        private readonly ApiContext _context = context;
        private readonly MqttService _mqttService = mqttService;
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly User systemUser = new()
        {
            Username = "H&M_System",
            Password = "password",
            Role = "Admin",
            Email = "system@hm.com"
        };
        public async Task  RestockBasedOnNotification()
        {
            try
            {
                var allAlerts = _context.Alerts.Where(alert => alert.Status == "Pending").ToList();

                if (allAlerts.IsNullOrEmpty())
                    throw new CustomException("No Restock Notification Found",404);

                RequestOrderItem[] inventoryUpdates = [];
                
                foreach(var alert in allAlerts){

                    var allProduct = _context.Products.Where(p => p.Id == alert.ProductId).Include(p => p.Supplier).ToList();
                    if (allProduct.IsNullOrEmpty())
                    {
                        Console.WriteLine($"404: No Product Found with this Id({alert.ProductId})");
                        continue;
                    }
                        

                    var product = allProduct[0];

                    var stockRequire = (int)Math.Ceiling((decimal)product.AverageDailyUsage! * 90) + 10;

                    new SMTPService().SendInventoryRequest(product.Supplier, product, stockRequire, systemUser);

                    product.CurrentStock += stockRequire;
                    product.UpdatedAt = DateTime.Now;

                    _context.SaveChanges();

                    _ = inventoryUpdates.Append(new() { ProductId = product.Id, Quantity = -1 * stockRequire });

                       
                    alert.Status = "Resolved";
                    alert.NotifiedAt = DateTime.Now;
                    _context.SaveChanges();

                    await _mqttService.PublishAsync("inventory/notificationAlert", JsonConvert.SerializeObject(alert, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

                }
                await _mqttService.PublishAsync("inventory/orderItems", JsonConvert.SerializeObject(inventoryUpdates));
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateAverageDailyUsageAndReorderPointForAllProducts()
        {
            _context.Database.ExecuteSqlRaw("EXEC UpdateAverageDailyUsageAndReorderPoint");
            return;
        }

        public async Task ProcessExcelAndPlaceOrders(string excelFilePath)
        {
            using var workbook = new XLWorkbook(excelFilePath);
            var worksheet = workbook.Worksheet(1);
            var rowCount = worksheet.LastRowUsed().RowNumber();

            for (int row = 2; row <= rowCount; row++)
            {
                var productId = (int)worksheet.Cell(row, 1).GetDouble();
                var quantity = (int)worksheet.Cell(row, 2).GetDouble();
                var res = await _orderRepository.PlaceOrder([ new() { ProductId = productId, Quantity = quantity } ]);

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public async Task GetTotalOrderInLast60Sec()
        {
            var result = _context.TotalSalesSPResponses.FromSqlRaw("Exec GetRecentOrderItems").ToList()[0];

            await _mqttService.PublishAsync("sales/overallSales", JsonConvert.SerializeObject(result));
        }

    }
}
