using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    /// <summary>
    /// Represents a product in the system.
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the cost price of the product.
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// Gets or sets the selling price of the product.
        /// </summary>
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost for the product, if applicable.
        /// </summary>
        public decimal? ShippingCost { get; set; }

        /// <summary>
        /// Gets or sets the discount on the product, if any.
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// Gets or sets the net profit for the product, after discount and shipping costs.
        /// </summary>
        public decimal? NetProfit { get; set; }

        /// <summary>
        /// Gets or sets the threshold value for reordering stock.
        /// </summary>
        public int? ThresholdValue { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the product's category.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the current stock level for the product.
        /// </summary>
        public int CurrentStock { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the product's supplier.
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the product record.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last update date of the product record.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        public virtual Category Category { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of order items associated with the product.
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        /// <summary>
        /// Gets or sets the supplier of the product.
        /// </summary>
        public virtual Supplier Supplier { get; set; } = null!;
    }
}
