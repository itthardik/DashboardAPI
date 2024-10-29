
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
using Microsoft.EntityFrameworkCore.Query;
using System.Net;
using DocumentFormat.OpenXml.EMMA;

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
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public IIncludableQueryable<Alert, Product> GetAllAlerts()
        {
            var allAlerts = _context.Alerts.Where(alert => alert.Status == "Pending").OrderByDescending(alert => alert.AlertLevel).Include(a => a.Product);
            if (allAlerts.IsNullOrEmpty())
                throw new CustomException("No Inventory Alerts found", (int)HttpStatusCode.OK);
            return allAlerts;
        }

        /// <summary>
        /// Get alert by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<Alert> GetAlertByProductId(int productId)
        {
            return [.. _context.Alerts.Where(alert => alert.ProductId == productId)];
        }

        /// <summary>
        /// Add Alerts
        /// </summary>
        /// <param name="alert"></param>
        public void AddAlert(Alert alert)
        {
            _context.Alerts.Add(alert);
            _context.SaveChanges();
        }

        /// <summary>
        /// Saves all changes made to the repository.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
