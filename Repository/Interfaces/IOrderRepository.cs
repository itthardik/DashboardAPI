using Dashboard.Models;
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
        /// Add Empty Order
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Order AddEmptyOrder(int userId);

        /// <summary>
        /// Add Order Item
        /// </summary>
        /// <param name="orderItem"></param>
        void AddOrderItem(OrderItem orderItem);
        
    }
}
