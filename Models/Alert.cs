using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dashboard.Models;

public partial class Alert
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AlertLevel { get; set; }

    public DateTime? NotifiedAt { get; set; }

    public string? Status { get; set; }
    public virtual Product Product { get; set; } = null!;
}
