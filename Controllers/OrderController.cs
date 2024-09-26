using Dashboard.Utility.Validation;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Dashboard.Repository.Interfaces;
using Dashboard.Models.DTOs.Request;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Order Controller
    /// </summary>
    /// <param name="orderRepository"></param>
    [ApiController]
    [Route("api/order")]
    public class OrderController(IOrderRepository orderRepository) : ControllerBase
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        /// <summary>
        /// Place New Order
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> PlaceOrder([FromBody] List<RequestOrderItem> products)
        {
            try
            {
                if (products.IsNullOrEmpty())
                    throw new CustomException("Empty List", 404);

                var res = await _orderRepository.PlaceOrder(products);
                return res;
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
    }
}
