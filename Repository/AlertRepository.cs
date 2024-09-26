
using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Dashboard.Repository
{
    /// <summary>
    /// Alert Repo
    /// </summary>
    /// <param name="context"></param>
    public class AlertRepository(ApiContext context) : IAlertRepository
    {
        private readonly ApiContext _context = context;

        /// <summary>
        /// Get All Alerts
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public JsonResult GetAllAlerts(int pageNumber, int pageSize)
        {
            var allAlerts = _context.Alerts.Where(alert => alert.Status == "Pending").OrderBy(alert => alert.AlertLevel).Include(a=>a.Product);
            if (allAlerts.IsNullOrEmpty())
                throw new CustomException("No Inventory Alerts found", 200);

            var maxPages = (int)Math.Ceiling((decimal)(allAlerts.Count()) / pageSize);

            var alertsByPagination = allAlerts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new JsonResult(new { maxPages, data = alertsByPagination.ToList() },
                                        new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles }
                                    ) { StatusCode = 200 };
        }
    }
}
