using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Repository.Interfaces
{
    /// <summary>
    /// Interface for Sales Respository
    /// </summary>
    public interface ISalesRepository
    {
        /// <summary>
        /// Get Sales Stats By Category Based On Days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        JsonResult GetSalesStatsByCategoryBasedOnDays(int days);

        /// <summary>
        /// Get Overall Sales Stats Based On Days
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        JsonResult GetOverallSalesStatsBasedOnDays(int year, int month, int day);

        /// <summary>
        /// Get Top Selling Products By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        JsonResult GetTopSellingProductsByPagination(int pageNumber, int pageSize);

        /// <summary>
        /// Get Top Selling Categories By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        JsonResult GetTopSellingCategoriesByPagination(int pageNumber, int pageSize);
    }
}
