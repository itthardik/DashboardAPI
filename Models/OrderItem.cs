using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    /// <summary>
    /// Represents an item in an order.
    /// </summary>
    public partial class OrderItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the product associated with the order item.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the order to which the item belongs.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price of the product at the time of order.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the status of the order item, if applicable.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets any discount applied to the order item.
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the order item record.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the order to which the order item belongs.
        /// </summary>
        public virtual Order Order { get; set; } = null!;

        /// <summary>
        /// Gets or sets the product associated with the order item.
        /// </summary>
        public virtual Product Product { get; set; } = null!;
    }
}
