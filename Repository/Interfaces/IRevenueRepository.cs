using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Repository.Interfaces
{
    /// <summary>
    /// Revenue Repo Interface
    /// </summary>
    public interface IRevenueRepository
    {

        /// <summary>
        /// Get Product by product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        JsonResult GetProductCostById(int id);

        /// <summary>
        /// Get Product by product name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        JsonResult GetProductCostByName(string name);

        /// <summary>
        /// Get Top search value by page and page size
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        JsonResult GetAllSearchValuesByPagination(int pageNumber, int pageSize);
        /// <summary>
        /// Get Revenue Stats Based On Days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        JsonResult GetRevenueStatsBasedOnDays(int days);
    }
}
