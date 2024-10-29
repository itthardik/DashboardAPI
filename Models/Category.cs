using System;
using System.Collections.Generic;

namespace Dashboard.Models;
#pragma warning disable 1591
public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = [];
}
