using Dashboard.Models;
using Dashboard.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Services.Interfaces
{
    /// <summary>
    /// Inventory Service interface
    /// </summary>
    public interface IInventoryService
    {
        /// <summary>
        /// Get Inventory By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filterKey"></param>
        /// <returns></returns>
        PaginatedResponse<Product> GetInventoryByPagination(int pageNumber, int pageSize, string filterKey);

        /// <summary>
        /// Add Inventory By Product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="stockRequire"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Product> AddInventoryByProductId(int productId, int stockRequire, string token);
    }
}
