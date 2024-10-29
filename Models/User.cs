using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dashboard.Models;

#pragma warning disable 1591
public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public string? SessionToken { get; set; }

    public DateTime? TokenExpirationTime { get; set; }

    public bool? IsTokenActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CustomerSearch> CustomerSearches { get; set; } = [];

    public virtual ICollection<Order> Orders { get; set; } = [];
}
