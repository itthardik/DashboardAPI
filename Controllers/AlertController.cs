using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Dashboard.Utility.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Alert Controller
    /// </summary>
    /// <param name="alertRepository"></param>
    [Route("api/alert")]
    [ApiController]
    public class AlertController(IAlertRepository alertRepository) : ControllerBase
    {
        private readonly IAlertRepository _alertRepository = alertRepository;

        /// <summary>
        /// Get alerts by pages
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("getAlerts")]
        [Authorize(Policy = "InventoryAccessPolicy")]
        public JsonResult GetAlertsByPagination(int pageNumber, int pageSize)
        {
            try
            {
                ValidationUtility.PageInfoValidator(pageNumber, pageSize);
                var res = _alertRepository.GetAllAlerts(pageNumber, pageSize);
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
