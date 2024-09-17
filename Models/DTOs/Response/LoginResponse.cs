using System.ComponentModel.DataAnnotations;

namespace RealTimeComTest.Models
{
    /// <summary>
    /// Login Respose model for session token login response
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Username is required and has limit between 2 to 300
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// Role of the User
        /// </summary>
        public string? Role { get; set; }
        /// <summary>
        /// Session token
        /// </summary>
        public string? SessionToken { get; set; }
        /// <summary>
        /// Token Expiration Time
        /// </summary>
        public DateTime? TokenExpirationTime { get; set; }
     }
}
