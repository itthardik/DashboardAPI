using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Services.Interfaces
{
    /// <summary>
    /// Freshdesk Service interface
    /// </summary>
    public interface IFreshdeskService
    {
        /// <summary>
        /// Get All Tickets with pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        Task<JsonResult> GetAllTickets(int pageNumber, int pageSize, string orderBy, string orderType);

        /// <summary>
        /// Get Tickets By Query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<JsonResult> GetTicketsByQuery(string query);

        /// <summary>
        /// Get ticket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JsonResult> GetTicketById(int id);

        /// <summary>
        /// Get stats of overall tokens
        /// </summary>
        /// <returns></returns>
        Task<JsonResult> GetOverallStats();

        /// <summary>
        /// Batch Post Ticket
        /// </summary>
        /// <returns></returns>
        Task AddMultipleTickets();
    }
}
