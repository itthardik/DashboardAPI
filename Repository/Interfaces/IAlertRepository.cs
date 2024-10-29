using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace Dashboard.Repository.Interfaces
{
    /// <summary>
    /// Interface for Alert Respository
    /// </summary>
    public interface IAlertRepository
    {
        /// <summary>
        /// Get All Repos
        /// </summary>
        /// <returns></returns>
        IIncludableQueryable<Alert, Product> GetAllAlerts();

        /// <summary>
        /// Get Alert By product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        List<Alert> GetAlertByProductId(int productId);

        /// <summary>
        /// Add Alert
        /// </summary>
        /// <param name="alert"></param>
        void AddAlert(Alert alert);

        /// <summary>
        /// Saves all changes made to the repository.
        /// </summary>
        void Save();
    }
}
