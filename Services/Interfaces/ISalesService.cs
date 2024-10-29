using Dashboard.Models;
using Dashboard.Models.DTOs.Response;

namespace Dashboard.Services.Interfaces
{
    /// <summary>
    /// Sales Service
    /// </summary>
    public interface ISalesService
    {
        /// <summary>
        /// Get Sales Stats By Category Based On Days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        List<SalesByCategorySPResponse> GetSalesStatsByCategoryBasedOnDays(string days);

        /// <summary>
        /// Get Overall Sales Stats Based On Days
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        List<OrderItem> GetOverallSalesStatsBasedOnDays(int year, int month, int day);

        /// <summary>
        /// Get Top Selling Products By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PaginatedResponse<TopSellingProductsSPResponse> GetTopSellingProductsByPagination(int pageNumber, int pageSize);

        /// <summary>
        /// Get Top Selling Categories By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PaginatedResponse<TopSellingProductsSPResponse> GetTopSellingCategoriesByPagination(int pageNumber, int pageSize);

        /// <summary>
        /// Get Last 10min Sales
        /// </summary>
        /// <returns></returns>
        List<TotalSalesSPResponse> GetLast10MinSales();
    }
}
