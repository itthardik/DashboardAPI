using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility;

namespace Dashboard.Repository
{
    /// <summary>
    /// Repository for managing user data.
    /// Provides methods for retrieving, adding, and saving users.
    /// </summary>
    /// <param name="context">The DbContext instance to use for database operations.</param>
    public class UserRepository(ApiContext context) : IUserRepository
    {
        private readonly ApiContext _context = context;

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The user with the specified username.</returns>
        /// <exception cref="CustomException">Thrown when no user with the specified username is found.</exception>
        public User GetUserByUserName(string username)
        {
            var result = _context.Users.Where(lg => lg.Username == username).ToList();

            if (result.Count == 0)
                throw new CustomException("Invalid Username") { StatusCode = 404};

            return result.First();
        }

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <exception cref="CustomException">Thrown when a user with the specified username already exists.</exception>
        public void AddNewUser(User user)
        {
            var existingUser = _context.Users.Where(lg => lg.Username == user.Username).FirstOrDefault();
            if (existingUser != null)
                throw new CustomException("User with this username exists");

            _context.Users.Add(user);
        }

        /// <summary>
        /// Saves all changes made to the repository.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
