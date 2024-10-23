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
    /// Revenue Repo
    /// </summary>
    /// <param name="apiContext"></param>
    public class RevenueRepository(ApiContext apiContext) : IRevenueRepository
    {
        private readonly ApiContext _context=apiContext;

        /// <summary>
        /// Get Top search value by page and page size
        /// </summary>
        /// <returns></returns>
        public IOrderedQueryable<CustomerSearch> GetAllOrderedSearchValues()
        {
            var allSearchValues = _context.CustomerSearches
                                .OrderByDescending(b => b.Count);
            if (!allSearchValues.Any())
                throw new CustomException("No Search Values found",404);

            return allSearchValues;
        }

        /// <summary>
        /// Get Top 10 Revenue And  Profit
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<RevenueSPResponse> GetRevenueStatsBasedOnDays(int days) {
            var result = _context.RevenueSPResponses
            .FromSqlRaw("EXEC GetTop10RevenueAndProfit @DaysBack;", new SqlParameter("@DaysBack",days))
            .ToList();

            return result;
        }
    }
}
