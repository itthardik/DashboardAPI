using Dashboard.Utility.Validation;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Dashboard.Repository.Interfaces;
using Dashboard.Models.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Dashboard.Services.Interfaces;
using Dashboard.Services;
using Hangfire;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Order Controller
    /// </summary>
    /// <param name="orderService"></param>
    [ApiController]
    [Route("api/order")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        /// <summary>
        /// Place New Order
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Policy= "FullAccessPolicy")]
        public async Task<JsonResult> PlaceOrder([FromBody] List<RequestOrderItem> products)
        {
            try
            {
                if (products.IsNullOrEmpty())
                    throw new CustomException("Empty List", 404);

                await _orderService.PlaceOrder(products);
                return new JsonResult("Order Placed Successfully") { StatusCode = 200 };
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        /// <summary>
        /// Start Live Orders Job
        /// </summary>
        /// <returns></returns>
        [HttpPost("start-live-orders-job")]
        public JsonResult LiveOrders()
        {
            try
            {
                _orderService.LiveOrders("Orders.xlsx");
                return new JsonResult("Job has been enqueued.") { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
