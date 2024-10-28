using Dashboard.Repository.Interfaces;
using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Dashboard.Utility.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Revenue Controller
    /// </summary>
    [Route("api/revenue")]
    [ApiController]
    public class RevenueController(IRevenueService revenueService) : Controller
    {
        private readonly IRevenueService _revenueService = revenueService;

        /// <summary>
        /// Get product from id or name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        [Authorize(Policy = "Inventory&RevenueAccessPolicy")]
        [HttpGet("productCost")]
        public JsonResult GetProductCostWithIdOrName([FromQuery] int? id, [FromQuery] string? name)
        {
            try
            {
                if (id != null)
                {
                    var result = _revenueService.GetProductCostById(id ?? 0);
                    return new JsonResult(new { data = result }) { StatusCode = (int)HttpStatusCode.OK };
                }
                else if (name != null)
                {
                    var result = _revenueService.GetProductCostByName(name);
                    return new JsonResult(new { data = result }) { StatusCode = (int)HttpStatusCode.OK };
                }
                throw new CustomException("Id or Name is required", 400);
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }
        
        
        /// <summary>
        /// Get All Search Values By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Authorize(Policy = "RevenueAccessPolicy")]
        [HttpGet("searchValues")]
        public JsonResult GetAllSearchValuesByPagination(int pageNumber, int pageSize)
        {
            try
            {
                ValidationUtility.PageInfoValidator(pageNumber, pageSize);
                var res = _revenueService.GetAllSearchValuesByPagination(pageNumber, pageSize);

                return new JsonResult(res) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        /// <summary>
        /// Get Revenue Stats Based On Days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        [Authorize(Policy = "RevenueAccessPolicy")]
        [HttpGet("revenueStats")]
        public JsonResult GetRevenueStatsBasedOnDays([FromQuery]string days)
        {
            try
            {
                var res = _revenueService.GetRevenueStatsBasedOnDays(days);

                return new JsonResult(new { data = res }) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

    }
}
