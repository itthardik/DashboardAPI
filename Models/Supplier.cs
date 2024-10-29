using System;
using System.Collections.Generic;

namespace Dashboard.Models;

#pragma warning disable 1591
public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = [];
}
