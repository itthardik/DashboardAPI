using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    /// <summary>
    /// Represents an order placed by a user.
    /// </summary>
    public partial class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the user who placed the order.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the total price of the order.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the status of the order (e.g., Pending, Shipped, Delivered).
        /// </summary>
        public string Status { get; set; } = null!;

        /// <summary>
        /// Gets or sets the creation date of the order.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last updated date of the order.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the collection of order items associated with the order.
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        /// <summary>
        /// Gets or sets the user who placed the order.
        /// </summary>
        public virtual User User { get; set; } = null!;
    }
}
