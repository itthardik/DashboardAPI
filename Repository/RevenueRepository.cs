﻿using Dashboard.DataContext;
using Dashboard.Models.DTOs.Response;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

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
        /// Get Product by product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetProductCostById(int id)
        {
            try
            {
                var product = _context.Products.Find(id) ?? throw new CustomException("No Product with this ID", 404);

                return new JsonResult(new {data = product }) { StatusCode = 200};
            }
            catch (CustomException ex) {
                return new JsonResult(ex.ErrorMessage){ StatusCode = ex.StatusCode };
            }
        }

        /// <summary>
        /// Get Product by product name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonResult GetProductCostByName(string name) {
            try
            {
                var product = _context.Products.Where(p => p.Name.Contains(name));
                if(product.IsNullOrEmpty())
                    throw new CustomException("No Product with this name",404);

                return new JsonResult(new { data = product.First() }) { StatusCode = 200 };
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage){ StatusCode = ex.StatusCode };
            }
        }

        /// <summary>
        /// Get Top search value by page and page size
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetAllSearchValuesByPagination(int pageNumber, int pageSize)
        {
            var allSearchValues = _context.CustomerSearches
                                .OrderByDescending(b => b.Count);
            if (!allSearchValues.Any())
                throw new CustomException("No Search Values found",404);

            var maxPages = (int)Math.Ceiling((decimal)(allSearchValues.Count()) / pageSize);

            var searchValuesByPagination = allSearchValues.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new JsonResult(new { maxPages, data = searchValuesByPagination });
        }

        /// <summary>
        /// Get Top 10 Revenue And  Profit
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public JsonResult GetRevenueStatsBasedOnDays(int days) {
            var result = _context.RevenueSPResponses
            .FromSqlRaw("EXEC GetTop10RevenueAndProfit @DaysBack = {0}", days)
            .ToList();

            return new JsonResult(new {data = result }) { StatusCode= 200};
        }
    }
}
