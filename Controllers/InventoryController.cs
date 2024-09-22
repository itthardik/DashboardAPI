using Dashboard.Repository;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility.Validation;
using Dashboard.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Inventory Controller
    /// </summary>
    /// <param name="inventoryRepository"></param>
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController(IInventoryRepository inventoryRepository) : Controller
    {
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository;

        /// <summary>
        /// Get Product / Inventory By Pagination and FilterKey
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filterKey"></param>
        /// <returns></returns>
        [HttpGet("getInventory")]
        [Authorize(Policy = "InventoryAccessPolicy")]
        public JsonResult GetProductByPagination(int pageNumber, int pageSize, string filterKey) {
            try
            {
                ValidationUtility.PageInfoValidator(pageNumber, pageSize);
                var res = _inventoryRepository.GetInventoryByPagination(pageNumber, pageSize, filterKey);
                return res;
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
        /// <summary>
        /// Add Inventory With Product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="stockRequire"></param>
        /// <returns></returns>
        [HttpPatch("addInventory")]
        [Authorize(Policy = "InventoryAccessPolicy")]
        public async Task<JsonResult> AddInventoryWithProductId([Required]int productId, [Required] int stockRequire) {
            try
            {
                if (stockRequire <= 0)
                    throw new CustomException("Stock cannot be negative or zero", 404);

                var token = Request.Cookies["jwtToken"];

                if (string.IsNullOrEmpty(token))
                    throw new CustomException("Token not found", 404);

                var res = await _inventoryRepository.AddInventoryByProductId(productId, stockRequire, token);
                return res;
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}
