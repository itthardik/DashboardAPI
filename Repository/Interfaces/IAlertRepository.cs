using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Repository.Interfaces
{
    public interface IAlertRepository
    {
        public JsonResult GetAllRepository(int pageNumber, int pageSize);
    }
}
