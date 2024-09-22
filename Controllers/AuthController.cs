using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using RealTimeComTest.Models.ViewModels.Request;
using RealTimeComTest.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Azure.Core;
using System.IdentityModel.Tokens.Jwt;
using Dashboard.Models;

namespace Dashboard.Controllers
{

    /// <summary>
    /// Auth controller
    /// </summary>
    [ApiController]
    [Route("auth")]
    public class AuthController(IConfiguration configuration, IUserRepository userRepository, BrokerService brokerService) : ControllerBase
    {
        private readonly Jwt _jwt = new (configuration);
        private readonly IUserRepository _userRepository = userRepository;
        private readonly BrokerService _brokerService = brokerService;
        private readonly int tokenLifeSpan = 20;
        private string GetHashedPassword(string password) {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(configuration["Hash:Secret"]!));
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password!);
            byte[] hashBytes = hmac.ComputeHash(passwordBytes);

            return Convert.ToBase64String(hashBytes);
        }
        private static string GenerateRandomBytes(int length)
        {
            var random = new Random();
            byte[] bytes = new byte[length];
            random.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }



        /// <summary>
        /// Login route
        /// </summary>
        /// <param name="requestUser"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<JsonResult> Login([FromHeader] RequestUser requestUser)
        {
            try
            {
                // Find the user by username
                var user = _userRepository.GetUserByUserName(requestUser.Username!);

                // Get the stored hashed password
                var hashedPassword = user.Password;
                // Hash the input password for comparison
                var hashedInputPassword = GetHashedPassword(requestUser.Password!);

                // Check if the hashed passwords match
                if (hashedInputPassword != hashedPassword)
                    throw new CustomException("Invalid Password") { StatusCode = 401};

                // Define claims (ID, username, role) for the user
                var claims = new[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, requestUser.Username!),
                    new Claim(ClaimTypes.Role, user.Role!)
                };

                // Create a JWT token with the defined claims
                var identity = new ClaimsIdentity(claims, "requestUser");
                var token = _jwt.GenerateJwtToken(identity);

                // Set options for the JWT cookie
                var jwtCookieOptions = new CookieOptions
                {
                    Path = "/",
                    HttpOnly = true,  // Cookie not accessible via JavaScript
                    Secure = true,    // Only sent over HTTPS
                    SameSite = SameSiteMode.None, // Allow cross-site requests
                    Expires = DateTime.UtcNow.AddMinutes(tokenLifeSpan) // Set cookie expiration
                };

                // Append the JWT token to the response cookies
                Response.Cookies.Append("jwtToken", token, jwtCookieOptions);

                // Generate a session token and update user properties
                user.SessionToken = GenerateRandomBytes(64);
                user.TokenExpirationTime = DateTime.UtcNow.AddMinutes(tokenLifeSpan);
                user.LastLogin = DateTime.UtcNow;
                user.IsTokenActive = true;

                // Save user details to the database
                _userRepository.Save();

                // Notify the broker service of the successful login
                await _brokerService.LoginUser(requestUser.Username!, user.SessionToken!, user.Role!);

                // Set options for the session token cookie
                var sessionCookieOptions = new CookieOptions
                {
                    Path = "/",
                    HttpOnly = false,  // Accessible via JavaScript
                    Secure = true,     // Only sent over HTTPS
                    SameSite = SameSiteMode.None, // Allow cross-site requests
                    Expires = DateTime.UtcNow.AddMinutes(tokenLifeSpan) // Set cookie expiration
                };

                // Prepare the response data
                var response = new LoginResponse()
                {
                    Username = requestUser.Username!,
                    Role = user.Role!,
                    TokenExpirationTime = user.TokenExpirationTime,
                    SessionToken = user.SessionToken!,
                };

                // Append the session token to the response cookies
                Response.Cookies.Append("sessionToken", JsonConvert.SerializeObject(response), sessionCookieOptions);

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
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }

        }
        
        
        
        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="requestUser"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost("signup")]
        public JsonResult SignUp([FromBody] RequestUser requestUser, [FromQuery] string role)
        {
            try
            {
                var hashedInputPassword = GetHashedPassword(requestUser.Password!);
                _userRepository.AddNewUser(new()
                {
                    Username = requestUser.Username!,
                    Password = hashedInputPassword,
                    Email = requestUser.Username + "@hm.com",
                    Role = role
                });
                _userRepository.Save();
                return new JsonResult(new { message = "Signup Successfully" });

            }
            catch (CustomException ex)
            {
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = 500 };
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

                // Read the JWT token using the token handler
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Extract the username from the token claims
                var username = jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("name"))?.Value;

                // Check if the username is missing in the token
                if (string.IsNullOrEmpty(username))
                {
                    throw new CustomException("Username not found in token", 404);
                }

                // Notify the broker service to log out the user
                await _brokerService.LogoutUser(username);

                // Retrieve the user from the repository and deactivate their token
                var user = _userRepository.GetUserByUserName(username);
                user.IsTokenActive = false;

                // Save the changes to the repository
                _userRepository.Save();

                // Delete the JWT token cookie
                Response.Cookies.Delete("jwtToken", new CookieOptions
                {
                    Path = "/",
                    Secure = true,
                    HttpOnly = true,  // Cookie not accessible via JavaScript
                    SameSite = SameSiteMode.None // Allow cross-site requests
                });

                // Delete the session token cookie
                Response.Cookies.Delete("sessionToken", new CookieOptions
                {
                    Path = "/",
                    Secure = true,
                    HttpOnly = false,  // Accessible via JavaScript
                    SameSite = SameSiteMode.None // Allow cross-site requests
                });

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
                return new JsonResult(ex.Message) { StatusCode = 500 };
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

                // Check if the token is missing
                if (string.IsNullOrEmpty(token))
                    throw new CustomException("Token not found", 404);

                // Validate the JWT token and extract the claims principal
                var principal = _jwt.ValidateJwtToken(token);
                if (principal != null)
                {
                    // Extract user ID, username, and role claims
                    var userIdClaim = principal.FindFirst(ClaimTypes.PrimarySid);
                    var usernameClaim = principal.FindFirst(ClaimTypes.Name);
                    var roleClaim = principal.FindFirst(ClaimTypes.Role);

                    // Check if any of the essential claims are missing
                    if (userIdClaim == null || usernameClaim == null || roleClaim == null)
                        throw new CustomException("Token claims are invalid", 400);

                    // Recreate the claims identity with the extracted claims
                    var claims = new[]
                    {
                        new Claim(type: ClaimTypes.PrimarySid, userIdClaim.Value),
                        new Claim(type: ClaimTypes.Name, usernameClaim.Value),
                        new Claim(type: ClaimTypes.Role, roleClaim.Value)
                    };

                    // Generate a new JWT token using the recreated claims
                    var identity = new ClaimsIdentity(claims, "requestUser");
                    var newToken = _jwt.GenerateJwtToken(identity);

                    // Set options for the new JWT token cookie
                    var jwtCookieOptions = new CookieOptions
                    {
                        Path = "/",
                        HttpOnly = true,  // Cookie not accessible via JavaScript
                        Secure = true,    // Only sent over HTTPS
                        SameSite = SameSiteMode.None, // Allow cross-site requests
                        Expires = DateTime.UtcNow.AddMinutes(tokenLifeSpan) // Set expiration
                    };

                    // Append the new JWT token to the response cookies
                    Response.Cookies.Append("jwtToken", newToken, jwtCookieOptions);

                    // Retrieve the user by username and update their session data
                    var user = _userRepository.GetUserByUserName(usernameClaim.Value);
                    user.SessionToken = GenerateRandomBytes(64);
                    user.TokenExpirationTime = DateTime.UtcNow.AddMinutes(tokenLifeSpan);
                    user.LastLogin = DateTime.UtcNow;
                    user.IsTokenActive = true;

                    // Save the updated user data to the repository
                    _userRepository.Save();

                    // Notify the broker service to refresh the user session
                    await _brokerService.RefreshUser(user.Username, user.SessionToken);

                    // Set options for the new session token cookie
                    var sessionCookieOptions = new CookieOptions
                    {
                        Path = "/",
                        HttpOnly = false,  // Accessible via JavaScript
                        Secure = true,     // Only sent over HTTPS
                        SameSite = SameSiteMode.None, // Allow cross-site requests
                        Expires = DateTime.UtcNow.AddMinutes(tokenLifeSpan) // Set expiration
                    };

                    // Prepare the response data
                    var response = new LoginResponse()
                    {
                        Username = user.Username,
                        Role = user.Role,
                        TokenExpirationTime = user.TokenExpirationTime,
                        SessionToken = user.SessionToken!,
                    };

                    // Append the session token to the response cookies
                    Response.Cookies.Append("sessionToken", JsonConvert.SerializeObject(response), sessionCookieOptions);

                    // Return success message for token refresh
                    return new JsonResult(new { message = "Token refreshed successfully" });
                }

                // Throw an error if the token is invalid
                throw new CustomException("Invalid token", 400);
            }
            catch (CustomException ex)
            {
                // Handle custom exceptions and return the appropriate error message
                return new JsonResult(ex.ErrorMessage) { StatusCode = ex.StatusCode };
            }
            catch (Exception ex)
            {
                // Handle any general exceptions and return a 500 status code
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }

        }

    }
}