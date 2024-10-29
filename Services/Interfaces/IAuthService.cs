using Dashboard.Models.DTOs.Response;
using RealTimeComTest.Models.ViewModels.Request;

namespace Dashboard.Services.Interfaces
{
    /// <summary>
    /// Interface for authentication-related services.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates the user with the given username and password. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<LoginServiceResponse> Login(string username, string password);

        /// <summary>
        /// Registers a new user with the given credentials and role.
        /// </summary>
        /// <param name="requestUser"></param>
        /// <param name="role"></param>
        void SignUp(RequestUser requestUser, string role);

        /// <summary>
        /// Logs the user out by invalidating the given token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task LogOut(string token);

        /// <summary>
        /// Refreshes the authentication token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<LoginServiceResponse> RefreshToken(string token);
    }
}
