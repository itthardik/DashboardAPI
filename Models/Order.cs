using System;
using System.Collections.Generic;

namespace Dashboard.Models;

#pragma warning disable 1591
public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = [];

    public virtual User User { get; set; } = null!;
}
