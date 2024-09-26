using Dashboard.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Repository.Interfaces
{
    /// <summary>
    /// Interface for Order Respository
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Place new Order
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        public Task<JsonResult> PlaceOrder(List<RequestOrderItem> orderItems);
    }
}
