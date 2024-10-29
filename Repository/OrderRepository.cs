using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Models.DTOs.Request;
using Dashboard.Repository.Interfaces;
using Dashboard.Services;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Dashboard.Repository
{
    /// <summary>
    /// Order Repo
    /// </summary>
    /// <param name="context"></param>
    public class OrderRepository(ApiContext context) : IOrderRepository
    {
        private readonly ApiContext _context = context;

        /// <summary>
        /// Add Empty Order
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Order AddEmptyOrder( int userId)
        {
            Order newOrder = new() { UserId = userId, TotalPrice = 0, Status = "Pending" };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }

        /// <summary>
        /// Add Order Item
        /// </summary>
        /// <param name="orderItem"></param>
        public void AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }
    }
}