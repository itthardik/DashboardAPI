using Dashboard.Models;
using Dashboard.Models.DTOs.Response;

namespace Dashboard.Repository.Interfaces
{
    /// <summary>
    /// Revenue Repo Interface
    /// </summary>
    public interface IRevenueRepository
    {
        /// <summary>
        /// Get Top search value by page and page size
        /// </summary>
        /// <returns></returns>
        IOrderedQueryable<CustomerSearch> GetAllOrderedSearchValues();
        /// <summary>
        /// Get Revenue Stats Based On Days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        List<RevenueSPResponse> GetRevenueStatsBasedOnDays(int days);
    }
}
