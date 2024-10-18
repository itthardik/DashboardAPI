using Dashboard.DataContext;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
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
        public JsonResult GetSalesStatsByCategoryBasedOnDays(int days)
        {
            var result = _context.SalesByCategorySPResponses
            .FromSqlRaw("EXEC GetTotalSalesByCategory @DaysBack = {0}", days)
            .ToList();

            return new JsonResult(new { data = result }) { StatusCode = 200 };
        }

        /// <summary>
        /// Get Overall Sales Stats Based On Days
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public JsonResult GetOverallSalesStatsBasedOnDays(int year, int month, int day)
        {
            var result = _context.OrderItems
                .FromSqlRaw("Exec GetOrderItemsByDate @SelectedDate = {0}", new DateTime(year, month, day))
                .ToList();

            return new JsonResult(new { data = result }) { StatusCode = 200 };
        }

        /// <summary>
        /// Get Top Selling Products By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public JsonResult GetTopSellingProductsByPagination(int pageNumber, int pageSize)
        {
            var topSellingProducts = _context.TopSellingProductsSPResponses.FromSqlRaw("Exec GetTopSellingProducts").ToList();
            
            if (topSellingProducts.IsNullOrEmpty())
                throw new CustomException("No Search Values found", 404);

            var maxPages = (int)Math.Ceiling((decimal)(topSellingProducts.Count) / pageSize);

            var topSellingProductsByPagination = topSellingProducts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new JsonResult(new { maxPages, data = topSellingProductsByPagination });
        }

        /// <summary>
        /// Get Top Selling Categories By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public JsonResult GetTopSellingCategoriesByPagination(int pageNumber, int pageSize)
        {
            var topSellingCategories = _context.TopSellingProductsSPResponses.FromSqlRaw("Exec GetCategorySalesSummary").ToList();

            if (topSellingCategories.IsNullOrEmpty())
                throw new CustomException("No Search Values found", 404);

            var maxPages = (int)Math.Ceiling((decimal)(topSellingCategories.Count) / pageSize);

            var topSellingCategoriesByPagination = topSellingCategories.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new JsonResult(new { maxPages, data = topSellingCategoriesByPagination });
        }

        /// <summary>
        /// Get Last 10min Sales Data
        /// </summary>
        /// <returns></returns>
        public JsonResult GetLast10MinSales()
        {
            var result = _context.TotalSalesSPResponses.FromSqlRaw("Exec GetLast10MinutesOrderItems").ToList();
            return new JsonResult(new {data = result } );
        }
    }
}
