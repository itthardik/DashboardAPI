using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Dashboard.Utility.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Revenue Controller
    /// </summary>
    [Route("api/revenue")]
    [ApiController]
    public class RevenueController(IRevenueRepository revenueRepository) : Controller
    {
        private readonly IRevenueRepository _revenueRepository = revenueRepository;

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
                    var result = _revenueRepository.GetProductCostById(id ?? 0);
                    return result;
                }
                else if (name != null)
                {
                    var result = _revenueRepository.GetProductCostByName(name);
                    return result;
                }
                throw new CustomException("Id or Name is required", 400);
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
                var res = _revenueRepository.GetAllSearchValuesByPagination(pageNumber, pageSize);
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
                var getDays = new Dictionary<string, int> {
                    { "today", 0 },
                    { "last3days", 3 },
                    { "lastweek", 7 },
                    { "lastmonth", 30 },
                    { "last3months", 90 },
                    { "last6months", 180 },
                    { "lastyear", 360}};
                var res = _revenueRepository.GetRevenueStatsBasedOnDays(getDays[days]);
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
