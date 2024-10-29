using System;
using System.Collections.Generic;

namespace Dashboard.Models;
#pragma warning disable 1591
public partial class OrderItem
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public string? Status { get; set; }

    public decimal? Discount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
