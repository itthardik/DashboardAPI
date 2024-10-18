using Dashboard.Repository.Interfaces;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Services
{
    public class RevenueService(IRevenueRepository revenueRepository)
    {
        private readonly IRevenueRepository _revenueRepository = revenueRepository;

        public JsonResult Test(int days)
        {
            var res = _revenueRepository.GetRevenueStatsBasedOnDays(days);
            return res;
        }
    }
}
