using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Dashboard.Utility.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/alert")]
    [ApiController]
    public class AlertController(IAlertRepository alertRepository) : ControllerBase
    {
        private readonly IAlertRepository _alertRepository = alertRepository;

        [HttpGet("getAlerts")]
        [Authorize(Policy = "InventoryAccessPolicy")]
        public JsonResult GetAlertsByPagination(int pageNumber, int pageSize)
        {
            try
            {
                ValidationUtility.PageInfoValidator(pageNumber, pageSize);
                var res = _alertRepository.GetAllRepository(pageNumber, pageSize);
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
