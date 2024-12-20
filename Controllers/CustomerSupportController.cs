﻿using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Dashboard.Utility.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Customer Support
    /// </summary>
    [ApiController]
    [Route("api/customerSupport")]
    public class CustomerSupportController(IFreshdeskService freshdeskService) : Controller
    {
        private readonly IFreshdeskService _freshdeskService = freshdeskService;


        /// <summary>
        /// Get All Tickets by Pagination
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllTickets")]
        [Authorize(Policy= "CustomerSupportAccessPolicy")]
        public async Task<JsonResult> GetAllTicketWithPagination(int pageNumber, int pageSize, string orderBy, string orderType)
        {
            try
            {
                ValidationUtility.PageInfoValidator(pageNumber, pageSize);
                var res = await _freshdeskService.GetAllTickets(pageNumber, pageSize, orderBy, orderType);
                return res;
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        /// <summary>
        /// Get Tickets by query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getTicketsByQuery")]
        [Authorize(Policy="CustomerSupportAccessPolicy")]
        public async Task<JsonResult> GetTicketsByQuery(string query)
        {
            try
            {
                var res = await _freshdeskService.GetTicketsByQuery(query);
                return res;
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        /// <summary>
        /// Get ticket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getTicket")]
        [Authorize(Policy="CustomerSupportAccessPolicy")]
        public async Task<JsonResult> GetTicketsByID(int id)
        {
            try
            {
                var res = await _freshdeskService.GetTicketById(id);
                return res;
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        /// <summary>
        /// Get Overall stats of Customer support
        /// </summary>
        /// <returns></returns>
        [HttpGet("getOverallStats")]
        [Authorize(Policy = "CustomerSupportAccessPolicy")]
        public async Task<JsonResult> GetOverallStats()
        {
            try
            {
                var res = await _freshdeskService.GetOverallStats();
                return res;
            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("batchPostTicket")]
        [Authorize(Policy = "CustomerSupportAccessPolicy")]
        public async Task AddMultipleTickets()
        {
            await _freshdeskService.AddMultipleTickets();
        }
    }
}
