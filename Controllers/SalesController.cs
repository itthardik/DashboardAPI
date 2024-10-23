using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Dashboard.Utility.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Sales Controller
    /// </summary>
    /// <param name="salesService"></param>
    [Route("api/sales")]
    [ApiController]
    public class SalesController(ISalesService salesService) : ControllerBase
    {
        private readonly ISalesService _salesService = salesService;

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
                var res = _salesService.GetSalesStatsByCategoryBasedOnDays(days);
                return new JsonResult(new { data = res}) { StatusCode = 200 };
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
                var res = _salesService.GetOverallSalesStatsBasedOnDays(year, month, day);
                return new JsonResult(new { data = res }) { StatusCode = 200 };
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
                //throw new NotImplementedException();
                ValidationUtility.PageInfoValidator(pageNumber, pageSize);
                var res = _salesService.GetTopSellingProductsByPagination(pageNumber, pageSize);
                return new JsonResult(res) { StatusCode = 200 };
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
                var res = _salesService.GetTopSellingCategoriesByPagination(pageNumber, pageSize);
                return new JsonResult(res) { StatusCode = 200 };
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

        /// <summary>
        /// Get ReatimData of last 10 min
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "SalesAccessPolicy")]
        [HttpGet("getLast10minSales")]
        public JsonResult GetRealtimeDateOfLast10Min()
        {
            try
            {
                var res = _salesService.GetLast10MinSales();
                return new JsonResult(new { data = res }) { StatusCode = 200 };
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
