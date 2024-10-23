using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Dashboard.Utility.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Alert Controller
    /// </summary>
    /// <param name="alertService"></param>
    [Route("api/alert")]
    [ApiController]
    public class AlertController(IAlertService alertService) : ControllerBase
    {
        private readonly IAlertService _alertService = alertService;

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
                var res = _alertService.GetAllAlerts(pageNumber, pageSize);
                return new JsonResult(res, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles }) { StatusCode = 200 };
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
