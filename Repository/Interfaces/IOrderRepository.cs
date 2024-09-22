using Dashboard.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public Task<JsonResult> PlaceOrder(List<RequestOrderItem> orderItems);
    }
}
