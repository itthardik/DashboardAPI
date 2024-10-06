using Dashboard.Utility.Validation;
using Dashboard.Utility;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Repository.Interfaces;
using Dashboard.Repository;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Customer Support
    /// </summary>
    [ApiController]
    [Route("api/customerSupport")]
    public class CustomerSupport(IFreshdeskRepository freshdeskRepository) : Controller
    {
        private readonly IFreshdeskRepository _freshdeskRepository = freshdeskRepository;


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
                var res = await _freshdeskRepository.GetAllTickets(pageNumber, pageSize, orderBy, orderType);
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
                var res = await _freshdeskRepository.GetTicketsByQuery(query);
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
                var res = await _freshdeskRepository.GetTicketById(id);
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
        /// Get Overall stats of Customer support
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getOverallStats")]
        [Authorize(Policy = "CustomerSupportAccessPolicy")]
        public async Task<JsonResult> GetOverallStats()
        {
            try
            {
                var res = await _freshdeskRepository.GetOverallStats();
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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("batchPostTicket")]
        [Authorize(Policy = "CustomerSupportAccessPolicy")]
        public async Task AddMultipleTickets()
        {
            await _freshdeskRepository.AddMultipleTickets();
        }
    }
}
