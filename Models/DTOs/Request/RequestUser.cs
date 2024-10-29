using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RealTimeComTest.Models.ViewModels.Request
{
    /// <summary>
    /// user request model
    /// </summary>
    public class RequestUser
    {
        /// <summary>
        /// Username is required and has a limit between 2 to 100 characters.
        /// </summary>
        [Required(ErrorMessage = "The Username field is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The Username must be between 2 and 100 characters.")]
        [FromHeader(Name = "Username")]
        public string? Username { get; set; }

        /// <summary>
        /// Password is required and has a limit between 8 to 64 characters.
        /// </summary>
        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "The password must be between 8 and 64 characters.")]
        [FromHeader(Name = "Password")]
        public string? Password { get; set; }
    }
}
