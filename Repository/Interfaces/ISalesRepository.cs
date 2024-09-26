using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Repository.Interfaces
{
    public interface ISalesRepository
    {
        JsonResult GetSalesStatsByCategoryBasedOnDays(int days);

        JsonResult GetOverallSalesStatsBasedOnDays(int year, int month, int day);

        JsonResult GetTopSellingProductsByPagination(int pageNumber, int pageSize);

        JsonResult GetTopSellingCategoriesByPagination(int pageNumber, int pageSize);
    }
}
