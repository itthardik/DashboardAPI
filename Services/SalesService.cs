﻿using Dashboard.Models;
using Dashboard.Models.DTOs.Response;
using Dashboard.Repository.Interfaces;
using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Microsoft.Extensions.Configuration;

namespace Dashboard.Services
{
    /// <summary>
    /// Sales Service
    /// </summary>
    public class SalesService(ISalesRepository salesRepository, IConfiguration configuration) : ISalesService
    {

        private readonly ISalesRepository _salesRepository = salesRepository;

        /// <summary>
        /// Get Sales Stats By Category Based On Days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public List<SalesByCategorySPResponse> GetSalesStatsByCategoryBasedOnDays(string days)
        {
            var getDays = configuration.GetSection("DaysSettings").Get<Dictionary<string, int>>();

            if (getDays == null || !getDays.TryGetValue(days, out int value))
                throw new CustomException("Invalid period");

            var result = _salesRepository.GetSalesStatsByCategoryBasedOnDays(value);
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
            var result = _salesRepository.GetOverallSalesStatsBasedOnDays(year, month, day);
            return result;
        }

        /// <summary>
        /// Get Top Selling Products By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public PaginatedResponse<TopSellingProductsSPResponse> GetTopSellingProductsByPagination(int pageNumber, int pageSize)
        {
            var topSellingProducts = _salesRepository.GetTopSellingProducts();

            var maxPages = (int)Math.Ceiling((decimal)(topSellingProducts.Count) / pageSize);

            var topSellingProductsByPagination = topSellingProducts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new () { MaxPages = maxPages, Data = topSellingProductsByPagination.ToList() };
        }

        /// <summary>
        /// Get Top Selling Categories By Pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public PaginatedResponse<TopSellingProductsSPResponse> GetTopSellingCategoriesByPagination(int pageNumber, int pageSize)
        {
            var topSellingCategories = _salesRepository.GetTopSellingCategories();

            var maxPages = (int)Math.Ceiling((decimal)(topSellingCategories.Count) / pageSize);

            var topSellingCategoriesByPagination = topSellingCategories.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new() { MaxPages = maxPages, Data = topSellingCategoriesByPagination.ToList() };
        }

        /// <summary>
        /// Get Last 10min Sales Data
        /// </summary>
        /// <returns></returns>
        public List<TotalSalesSPResponse> GetLast10MinSales()
        {
            var result = _salesRepository.GetLast10MinSales();
            return result;
        }
    }
}
