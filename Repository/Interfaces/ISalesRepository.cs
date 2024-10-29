using Dashboard.Models;
using Dashboard.Models.DTOs.Response;

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
        List<SalesByCategorySPResponse> GetSalesStatsByCategoryBasedOnDays(int days);

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
        /// <returns></returns>
        List<TopSellingProductsSPResponse> GetTopSellingProducts();

        /// <summary>
        /// Get Top Selling Categories By Pagination
        /// </summary>
        /// <returns></returns>
        List<TopSellingProductsSPResponse> GetTopSellingCategories();

        /// <summary>
        /// Get Last 10min Sales
        /// </summary>
        /// <returns></returns>
        List<TotalSalesSPResponse> GetLast10MinSales();
    }
}
