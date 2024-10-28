using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Dashboard.Repository.Interfaces;
using Dashboard.Services.Interfaces;
using Dashboard.Models.DTOs.Response;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Dashboard.Services
{
    /// <summary>
    /// Alert service
    /// </summary>
    /// <param name="alertRepository"></param>
    public class AlertService( IAlertRepository alertRepository) :IAlertService
    {
        private readonly IAlertRepository _alertRepository = alertRepository;

        /// <summary>
        /// Get all alerts
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PaginatedResponse<Alert> GetAllAlerts(int pageNumber, int pageSize)
        {
            var allAlerts = _alertRepository.GetAllAlerts();

            var maxPages = (int)Math.Ceiling((decimal)(allAlerts.Count()) / pageSize);

            var alertsByPagination = allAlerts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new() { MaxPages = maxPages, Data = [.. alertsByPagination] };
        }
    }
}
