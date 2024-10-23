using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealTimeComTest.Models.ViewModels.Request;

namespace Dashboard.Controllers
{

    /// <summary>
    /// Auth controller
    /// </summary>
    [ApiController]
    [Route("auth")]
    public class AuthController(IAuthService authService, IConfiguration configuration) : ControllerBase
    {
        private readonly IAuthService _authService= authService;

        // Set options for the JWT cookie
        private readonly CookieOptions jwtCookieOptions = new ()
        {
            Path = "/",
            HttpOnly = true,  // Cookie not accessible via JavaScript
            Secure = true,    // Only sent over HTTPS
            SameSite = SameSiteMode.None, // Allow cross-site requests
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpirationTime"])) // Set cookie expiration
        };

        // Set options for the session token cookie
        private readonly CookieOptions sessionCookieOptions = new ()
        {
            Path = "/",
            HttpOnly = false,  // Accessible via JavaScript
            Secure = true,     // Only sent over HTTPS
            SameSite = SameSiteMode.None, // Allow cross-site requests
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpirationTime"])) // Set cookie expiration
        };


        /// <summary>
        /// Login route
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<JsonResult> Login([FromHeader] string Username, [FromHeader] string Password)
        {
            try
            {
                var loginResponse = await _authService.Login(Username, Password);
                
                // Append the JWT token to the response cookies
                Response.Cookies.Append("jwtToken", loginResponse.Token, jwtCookieOptions);

                // Append the session token to the response cookies
                Response.Cookies.Append("sessionToken", JsonConvert.SerializeObject(loginResponse.LoginResponse), sessionCookieOptions);

                // Return success message
                return new JsonResult(new { message = "Login Successfully" });
            }
            catch (CustomException ex)
            {
                // Handle custom exceptions and return the appropriate error message
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                // Handle any general exceptions and return a 500 status code
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = 500 };
            }

        }



        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="requestUser"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [Authorize(Policy = "FullAccessPolicy")]
        [HttpPost("signup")]
        public JsonResult SignUp([FromBody] RequestUser requestUser, [FromQuery] string role)
        {
            try
            {
                _authService.SignUp(requestUser, role);
                return new JsonResult(new { message = "Signup Successfully" });

            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

           
        /// <summary>
        /// Log Out Route
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("logout")]
        public async Task<JsonResult> Logout()
        {
            try
            {
                // Retrieve the JWT token from the cookies
                var token = Request.Cookies["jwtToken"];

                // Check if the token is missing
                if (string.IsNullOrEmpty(token))
                {
                    throw new CustomException("Token not found", 404);
                }

                await _authService.LogOut(token);

                // Delete the JWT token cookie
                Response.Cookies.Delete("jwtToken", jwtCookieOptions);

                // Delete the session token cookie
                Response.Cookies.Delete("sessionToken", sessionCookieOptions);

                // Return a success message for logout
                return new JsonResult(new { message = "Logout successful" });
            }
            catch (CustomException ex)
            {
                // Handle custom exceptions and return the appropriate error message
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                // Handle any general exceptions and return a 500 status code
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = 500 };
            }

        }

        
        /// <summary>
        /// Refresh token for auth
        /// </summary>
        /// <returns></returns>
        [HttpPost("refresh")]
        public async Task<JsonResult> RefreshToken()
        {
            try
            {
                // Retrieve the existing JWT token from the cookies
                var token = Request.Cookies["jwtToken"];
                if (string.IsNullOrEmpty(token))
                    throw new CustomException("Token not found", 404);

                var refreshResponse = await _authService.RefreshToken(token);

                // Append the new JWT token to the response cookies
                Response.Cookies.Append("jwtToken", refreshResponse.Token, jwtCookieOptions);

                // Append the session token to the response cookies
                Response.Cookies.Append("sessionToken", JsonConvert.SerializeObject(refreshResponse.LoginResponse), sessionCookieOptions);

                // Return success message for token refresh
                return new JsonResult(new { message = "Token refreshed successfully" });
            }
            catch (CustomException ex)
            {
                // Handle custom exceptions and return the appropriate error message
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                // Handle any general exceptions and return a 500 status code
                ex.LogException(); return new JsonResult(ex.Message) { StatusCode = 500 };
            }

        }

    }
}