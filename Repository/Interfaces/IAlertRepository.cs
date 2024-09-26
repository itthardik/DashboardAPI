using Microsoft.AspNetCore.Mvc;

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
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetAllAlerts(int pageNumber, int pageSize);
    }
}
