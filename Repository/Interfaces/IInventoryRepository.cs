using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Repository.Interfaces
{
    /// <summary>
    /// Inventory Repoistory Interface
    /// </summary>
    public interface IInventoryRepository
    {
        /// <summary>
        /// Get Inventory By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filterKey"></param>
        /// <returns></returns>
        JsonResult GetInventoryByPagination(int pageNumber, int pageSize, string filterKey);

        /// <summary>
        /// Add Inventory By Product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="stockRequire"></param>
        /// <param name="token"></param>
        /// <returns></returns>
         Task<JsonResult> AddInventoryByProductId(int productId, int stockRequire, string token);

    }
}
