using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dashboard.Models;
#pragma warning disable 1591
public partial class Alert
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AlertLevel { get; set; }

    public DateTime? NotifiedAt { get; set; }

    public string? Status { get; set; }
    public virtual Product Product { get; set; } = null!;
}
