using Dashboard.DataContext;
using Dashboard.Repository.Interfaces;
using Dashboard.Services;
using Dashboard.Utility;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Dashboard.Repository
{
    public class SalesRepository(ApiContext apiContext) : ISalesRepository
    {
        private readonly ApiContext _context = apiContext;
        public JsonResult GetSalesStatsByCategoryBasedOnDays(int days)
        {
            var result = _context.SalesByCategorySPResponses
            .FromSqlRaw("EXEC GetTotalSalesByCategory @DaysBack = {0}", days)
            .ToList();

            return new JsonResult(new { data = result }) { StatusCode = 200 };
        }

        public JsonResult GetOverallSalesStatsBasedOnDays(int year, int month, int day)
        {
            var result = _context.OrderItems
                .FromSqlRaw("Exec GetOrderItemsByDate @SelectedDate = {0}", new DateTime(year, month, day))
                .ToList();

            return new JsonResult(new { data = result }) { StatusCode = 200 };
        }

        public JsonResult GetTopSellingProductsByPagination(int pageNumber, int pageSize)
        {
            var topSellingProducts = _context.TopSellingProductsSPResponses.FromSqlRaw("Exec GetTopSellingProducts").ToList();
            
            if (topSellingProducts.IsNullOrEmpty())
                throw new CustomException("No Search Values found", 404);

            var maxPages = (int)Math.Ceiling((decimal)(topSellingProducts.Count) / pageSize);

            var topSellingProductsByPagination = topSellingProducts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new JsonResult(new { maxPages, data = topSellingProductsByPagination });
        }

        public JsonResult GetTopSellingCategoriesByPagination(int pageNumber, int pageSize)
        {
            var topSellingCategories = _context.TopSellingProductsSPResponses.FromSqlRaw("Exec GetCategorySalesSummary").ToList();

            if (topSellingCategories.IsNullOrEmpty())
                throw new CustomException("No Search Values found", 404);

            var maxPages = (int)Math.Ceiling((decimal)(topSellingCategories.Count) / pageSize);

            var topSellingCategoriesByPagination = topSellingCategories.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new JsonResult(new { maxPages, data = topSellingCategoriesByPagination });
        }
    }
}
