using Dashboard.Utility.Validation;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Dashboard.Repository.Interfaces;
using Dashboard.Models.DTOs.Request;

namespace Dashboard.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class OrderController(IOrderRepository orderRepository) : ControllerBase
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

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
