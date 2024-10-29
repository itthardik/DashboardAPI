using Dashboard.Models;
using Dashboard.Models.DTOs.Response;
using Dashboard.Repository.Interfaces;
using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Microsoft.Extensions.Configuration;

namespace Dashboard.Services
{
    /// <summary>
    /// Revenue Service
    /// </summary>
    /// <param name="revenueRepository"></param>
    /// <param name="productRepository"></param>
    /// <param name="configuration"></param>
    public class RevenueService(IRevenueRepository revenueRepository, IProductRepository productRepository, IConfiguration configuration) : IRevenueService
    {
        private readonly IRevenueRepository _revenueRepository = revenueRepository;
        private readonly IProductRepository _productRepository = productRepository;

        /// <summary>
        /// Get Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Product> GetProductCostById(int id)
        {
            var result = _productRepository.GetProductById(id);

            return result;
        }

        /// <summary>
        /// Get Product by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Product> GetProductCostByName(string name) 
        {
            var result = _productRepository.GetProductsThatContainsName(name);

            return result;
        }

        /// <summary>
        /// Get Ordered Paginated response of customer search
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PaginatedResponse<CustomerSearch> GetAllSearchValuesByPagination(int pageNumber, int pageSize)
        {
            var allSearchValues = _revenueRepository.GetAllOrderedSearchValues();

            var maxPages = (int)Math.Ceiling((decimal)(allSearchValues.Count()) / pageSize);

            var searchValuesByPagination = allSearchValues.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new () { MaxPages = maxPages, Data = [.. searchValuesByPagination] };
        }

        /// <summary>
        /// Get Revenue Stats based on days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<RevenueSPResponse> GetRevenueStatsBasedOnDays(string days)
        {
            var getDays = configuration.GetSection("DaysSettings").Get<Dictionary<string, int>>();

            if (getDays == null || !getDays.TryGetValue(days, out int value))
                throw new CustomException("Invalid period");

            var result = _revenueRepository.GetRevenueStatsBasedOnDays(value);

            return result;
        }
    }
}
