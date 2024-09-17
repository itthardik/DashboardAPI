using System;
using System.Collections.Generic;

namespace Dashboard.Models;

/// <summary>
/// Represents a user in the system.
/// </summary>
public partial class User
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    /// <example>john_doe</example>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    /// <example>Password@123</example>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    /// <example>admin</example>
    public string Role { get; set; } = null!;

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    /// <example>john_doe@example.com</example>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last login date and time of the user.
    /// </summary>
    /// <example>2024-09-17T15:23:30</example>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    /// Gets or sets the session token of the user.
    /// </summary>
    /// <example>abcd1234sessiontoken</example>
    public string? SessionToken { get; set; }

    /// <summary>
    /// Gets or sets the expiration time of the session token.
    /// </summary>
    /// <example>2024-09-18T15:23:30</example>
    public DateTime? TokenExpirationTime { get; set; }

    /// <summary>
    /// Indicates whether the token is currently active.
    /// </summary>
    /// <example>true</example>
    public bool? IsTokenActive { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user was created.
    /// </summary>
    /// <example>2023-09-15T10:45:00</example>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the collection of customer searches associated with the user.
    /// </summary>
    public virtual ICollection<CustomerSearch> CustomerSearches { get; set; } = new List<CustomerSearch>();

    /// <summary>
    /// Gets or sets the collection of orders associated with the user.
    /// </summary>
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
