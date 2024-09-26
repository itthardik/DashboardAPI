using Dashboard.Repository;
using Dashboard.Repository.Interfaces;
using Dashboard.Services;
using Dashboard.Utility;
using Dashboard.Utility.Validation;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Sales Controller
    /// </summary>
    /// <param name="salesRepository"></param>
    [Route("api/sales")]
    [ApiController]
    public class SalesController(ISalesRepository salesRepository) : ControllerBase
    {
        private readonly ISalesRepository _salesRepository = salesRepository;

        /// <summary>
        /// Get Sales by Category
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        [Authorize(Policy = "SalesAccessPolicy")]
        [HttpGet("salesStatsByCategory")]
        public JsonResult GetSalesStatsByCategoryBasedOnDays([FromQuery] string days)
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
                var res = _salesRepository.GetSalesStatsByCategoryBasedOnDays(getDays[days]);
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
        /// Get Overall Sales
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        [Authorize(Policy = "SalesAccessPolicy")]
        [HttpGet("overallSalesStats")]
        public JsonResult GetOverallSalesStatsBasedOnDays(int year, int month, int day)
        {
            try
            {
                var res = _salesRepository.GetOverallSalesStatsBasedOnDays(year, month, day);
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
        /// Get Top Selling Products
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Authorize(Policy = "SalesAccessPolicy")]
        [HttpGet("topProducts")]
        public JsonResult GetTopSellingProductsByPagination(int pageNumber, int pageSize)
        {
            try
            {
                ValidationUtility.PageInfoValidator(pageNumber, pageSize);
                var res = _salesRepository.GetTopSellingProductsByPagination(pageNumber, pageSize);
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
        /// Get Top Selling Categories
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Authorize(Policy = "SalesAccessPolicy")]
        [HttpGet("topCategories")]
        public JsonResult GetTopSellingCategoriesByPagination(int pageNumber, int pageSize)
        {
            try
            {
                ValidationUtility.PageInfoValidator(pageNumber, pageSize);
                var res = _salesRepository.GetTopSellingCategoriesByPagination(pageNumber, pageSize);
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
