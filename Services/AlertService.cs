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
    public class AlertService( IAlertRepository alertRepository) :IAlertService
    {
        private readonly IAlertRepository _alertRepository = alertRepository;
        public PaginatedResponse<Alert> GetAllAlerts(int pageNumber, int pageSize)
        {
            var allAlerts = _alertRepository.GetAllAlerts();

            var maxPages = (int)Math.Ceiling((decimal)(allAlerts.Count()) / pageSize);

            var alertsByPagination = allAlerts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new() { MaxPages = maxPages, Data = [.. alertsByPagination] };
        }
    }
}
