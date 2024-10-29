using Dashboard.Models;
using Dashboard.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Services.Interfaces
{
    public interface IAlertService
    {
        PaginatedResponse<Alert> GetAllAlerts(int pageNumber, int pageSize);
    }
}
