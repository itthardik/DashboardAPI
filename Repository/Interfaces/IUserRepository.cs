using Dashboard.Models;

namespace Dashboard.Repository.Interfaces
{
    /// <summary>
    /// Interface for user repository operations.
    /// Provides methods for managing user data.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The user with the specified username.</returns>
        User GetUserByUserName(string username);

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">The user to add.</param>
        void AddNewUser(User user);

        /// <summary>
        /// Saves all changes made to the repository.
        /// </summary>
        void Save();
    }
}
