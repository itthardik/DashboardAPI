using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Models.DTOs.Response;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Dashboard.Repository
{
    /// <summary>
    /// Sales Repo
    /// </summary>
    /// <param name="apiContext"></param>
    public class SalesRepository(ApiContext apiContext) : ISalesRepository
    {
        private readonly ApiContext _context = apiContext;

        /// <summary>
        /// Get Sales Stats By Category Based On Days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<SalesByCategorySPResponse> GetSalesStatsByCategoryBasedOnDays(int days)
        {
            var result = _context.SalesByCategorySPResponses
            .FromSqlRaw("EXEC GetTotalSalesByCategory @DaysBack", new SqlParameter("@DaysBack",days))
            .ToList();

            return result;
        }

        /// <summary>
        /// Get Overall Sales Stats Based On Days
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public List<OrderItem> GetOverallSalesStatsBasedOnDays(int year, int month, int day)
        {
            var result = _context.OrderItems
                .FromSqlRaw("Exec GetOrderItemsByDate @SelectedDate", new SqlParameter("@SelectedDate",new DateTime(year, month, day)))
                .ToList();

            return result;
        }

        /// <summary>
        /// Get Top Selling Products By Pagination
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public List<TopSellingProductsSPResponse> GetTopSellingProducts()
        {
            var topSellingProducts = _context.TopSellingProductsSPResponses.FromSqlRaw("Exec GetTopSellingProducts").ToList();
            
            if (topSellingProducts.IsNullOrEmpty())
                throw new CustomException("No Search Values found", 404);

            return topSellingProducts;
        }

        /// <summary>
        /// Get Top Selling Categories By Pagination
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public List<TopSellingProductsSPResponse> GetTopSellingCategories()
        {
            var topSellingCategories = _context.TopSellingProductsSPResponses.FromSqlRaw("Exec GetCategorySalesSummary").ToList();

            if (topSellingCategories.IsNullOrEmpty())
                throw new CustomException("No Search Values found", 404);

            return topSellingCategories;
        }

        /// <summary>
        /// Get Last 10min Sales Data
        /// </summary>
        /// <returns></returns>
        public List<TotalSalesSPResponse> GetLast10MinSales()
        {
            var result = _context.TotalSalesSPResponses.FromSqlRaw("Exec GetLast10MinutesOrderItems").ToList();
            return result;
        }
    }
}
