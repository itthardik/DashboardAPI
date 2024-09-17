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
        /// Username is required and has limit between 2 to 300
        /// </summary>
        [Required(ErrorMessage = "The Username field is required.")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "The Username must be between 2 and 300 characters.")]
        [FromHeader(Name = "Username")]
        public string? Username { get; set; }
        /// <summary>
        /// Password is Required 
        /// </summary>
        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "The password must be between 1 and 300 characters.")]
        [FromHeader(Name = "Password")]
        public string? Password { get; set; }
    }
}
