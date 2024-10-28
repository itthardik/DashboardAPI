using Dashboard.Models.DTOs.Response;
using Dashboard.Repository.Interfaces;
using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using RealTimeComTest.Models;
using RealTimeComTest.Models.ViewModels.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Dashboard.Services
{
    /// <summary>
    /// Auth Service Handler
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="configuration"></param>
    /// <param name="brokerService"></param>
    public class AuthService(IUserRepository userRepository, IConfiguration configuration, BrokerService brokerService) : IAuthService
    {
        private readonly int tokenLifeSpan = Convert.ToInt32(configuration["Jwt:ExpirationTime"]);
        private readonly BrokerService _brokerService = brokerService;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly Jwt _jwt = new(configuration);

        private string GetHashedPassword(string password)
        {
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
        /// Login Handler
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<LoginServiceResponse> Login(string Username, string Password)
        {
            // Find the user by username
            var user = _userRepository.GetUserByUserName(Username!);

            // Get the stored hashed password
            var hashedPassword = user.Password;
            // Hash the input password for comparison
            var hashedInputPassword = GetHashedPassword(Password!);

            // Check if the hashed passwords match
            if (hashedInputPassword != hashedPassword)
                throw new CustomException("Invalid Password") { StatusCode = (int) HttpStatusCode.Unauthorized };

            // Define claims (ID, username, role) for the user
            var claims = new[]
            {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, Username!),
                    new Claim(ClaimTypes.Role, user.Role!)
                };

            // Create a JWT token with the defined claims
            var identity = new ClaimsIdentity(claims, "requestUser");
            var token = _jwt.GenerateJwtToken(identity);

            // Generate a session token and update user properties
            user.SessionToken = GenerateRandomBytes(64);
            user.TokenExpirationTime = DateTime.UtcNow.AddMinutes(tokenLifeSpan);
            user.LastLogin = DateTime.UtcNow;
            user.IsTokenActive = true;

            // Save user details to the database
            _userRepository.Save();

            // Notify the broker service of the successful login
            await _brokerService.LoginUser(Username!, user.SessionToken!, user.Role!);

            // Prepare the response data
            var response = new LoginResponse()
            {
                Username = Username!,
                Role = user.Role!,
                TokenExpirationTime = user.TokenExpirationTime,
                SessionToken = user.SessionToken!,
            };

            return new() { LoginResponse = response, Token = token };

        }

        /// <summary>
        /// SignUp Handler
        /// </summary>
        /// <param name="requestUser"></param>
        /// <param name="role"></param>
        public void SignUp(RequestUser requestUser, string role)
        {
            var hashedInputPassword = GetHashedPassword(requestUser.Password!);
            _userRepository.AddNewUser(new()
            {
                Username = requestUser.Username!,
                Password = hashedInputPassword,
                Email = requestUser.Username + "@hm.com",
                Role = role
            });
        }

        /// <summary>
        /// Logout Handler
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task LogOut(string token)
        {
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
        }

        /// <summary>
        /// Refresh Handler
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<LoginServiceResponse> RefreshToken(string token)
        {
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

                // Prepare the response data
                var response = new LoginResponse()
                {
                    Username = user.Username,
                    Role = user.Role,
                    TokenExpirationTime = user.TokenExpirationTime,
                    SessionToken = user.SessionToken!,
                };
                return new () { Token = newToken, LoginResponse = response };
            }
            throw new CustomException("Invalid token", 400);
        }
    }
}
