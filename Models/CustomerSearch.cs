using System;
using System.Collections.Generic;

namespace Dashboard.Models;
#pragma warning disable 1591
public partial class CustomerSearch
{
    public int Id { get; set; }

    public string SearchTerm { get; set; } = null!;

    public int? Count { get; set; }

    public int UserId { get; set; }

    public DateTime? SearchedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
