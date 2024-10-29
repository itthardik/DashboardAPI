using System;
using System.Collections.Generic;

namespace Dashboard.Models;

#pragma warning disable 1591
public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal CostPrice { get; set; }

    public decimal SellingPrice { get; set; }

    public decimal? ShippingCost { get; set; }

    public decimal? Discount { get; set; }

    public decimal? NetProfit { get; set; }

    public int? ReorderPoint { get; set; }

    public int CategoryId { get; set; }

    public int CurrentStock { get; set; }

    public int SupplierId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public decimal? AverageDailyUsage { get; set; }

    public virtual ICollection<Alert> Alerts { get; set; } = [];

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = [];

    public virtual Supplier Supplier { get; set; } = null!;
}
