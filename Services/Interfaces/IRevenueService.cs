using Dashboard.Models;
using Dashboard.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Services.Interfaces
{
    /// <summary>
    /// Interface for revenue service
    /// </summary>
    public interface IRevenueService
    {
        /// <summary>
        /// Get Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Product> GetProductCostById(int id);

        /// <summary>
        /// Get Product by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Product> GetProductCostByName(string name);

        /// <summary>
        /// Get all search values
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PaginatedResponse<CustomerSearch> GetAllSearchValuesByPagination(int pageNumber, int pageSize);

        /// <summary>
        /// get revenue stats
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        List<RevenueSPResponse> GetRevenueStatsBasedOnDays(string days);
    }
}
