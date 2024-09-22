using System;
using System.Collections.Generic;

namespace Dashboard.Models;

/// <summary>
/// Represents a user in the system.
/// </summary>
public partial class User
{
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    /// <example>john_doe</example>
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public string? SessionToken { get; set; }

    public DateTime? TokenExpirationTime { get; set; }

    public bool? IsTokenActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CustomerSearch> CustomerSearches { get; set; } = new List<CustomerSearch>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
