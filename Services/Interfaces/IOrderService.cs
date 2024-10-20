using Dashboard.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Services.Interfaces
{
    /// <summary>
    /// Order Service Interface
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Place new Order
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        Task PlaceOrder(List<RequestOrderItem> orderItems);

        /// <summary>
        /// Get Live Orders
        /// </summary>
        /// <param name="fileName"></param>
        void LiveOrders(string fileName);

    }
}
