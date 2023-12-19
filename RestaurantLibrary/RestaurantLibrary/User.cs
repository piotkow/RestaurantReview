using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    /// <summary>
    /// Represents the role of a user.
    /// </summary>
    public enum Role
    {
        User,
        Admin
    }

    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }


        public string Password { get; set; }

        public Role Role { get; set; }

        /// <summary>
        /// Initializes a new instance of the User class with default values.
        /// </summary>
        public User()
        {
            Id = -1;
        }

        /// <summary>
        /// Initializes a new instance of the User class with specified values.
        /// </summary>
        /// <param name="idVal">The ID of the user.</param>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="role">The role of the user.</param>
        public User(int idVal, string username, string password, Role role)
        {
            Id = idVal;
            UserName = username;
            Password = password;
            Role = role;
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        /// <param name="role">The role of the new user.</param>
        /// <param name="fileManager">The file manager that handles the storage of users.</param>
        /// <returns>Returns true if the user is successfully added, false otherwise.</returns>
        public bool AddNewUser(string username, string password, Role role, FileManager<User> fileManager)
        {
            List<User> users = fileManager.GetAllItemsFromFile() ?? new List<User>();
            int id=users.Max(x=>x.Id)+1;
            if (users.Any(user => user.Id == id) || users.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"User with ID or user with that username already exists. Cannot create a new user with the same ID or username.");
                return false;
            }

          
            User user = new User(id, username, password, role);
            fileManager.Add(user);
            return true;

        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="fileManager">The file manager that handles the storage of users.</param>
        /// <returns>Returns the logged in user if successful, a new user otherwise.</returns>
        public static User LogIn(string username, string password, FileManager<User> fileManager)
        {
            List<User> users = fileManager.GetAllItemsFromFile() ?? new List<User>();

            User? loggedInUser = users.FirstOrDefault(user =>
                user.UserName == username &&
                user.Password == password);

            return loggedInUser ?? new User();
        }

        /// <summary>
        /// Searches for a user by name.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="fileManager">The file manager that handles the storage of users.</param>
        /// <returns>Returns the user if found, null otherwise.</returns>
        public static User SearchByName(string name, FileManager<User> fileManager)
        {
            return fileManager.GetAllItemsFromFile().Find(x=>x.UserName == name);
        }

    }
}
