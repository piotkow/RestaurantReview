using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public enum Role
    {
        User,
        Admin
    }
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }


        public string Password { get; set; }

        public Role Role { get; set; }

        public User()
        {
            Id = -1;
        }

        public User(int idVal, string username, string password, Role role)
        {
            Id = idVal;
            UserName = username;
            Password = password;
            Role = role;
        }

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

        public static User LogIn(string username, string password, FileManager<User> fileManager)
        {
            List<User> users = fileManager.GetAllItemsFromFile() ?? new List<User>();

            User? loggedInUser = users.FirstOrDefault(user =>
                user.UserName == username &&
                user.Password == password);

            return loggedInUser ?? new User();
        }

        public static User SearchByName(string name, FileManager<User> fileManager)
        {
            return fileManager.GetAllItemsFromFile().Find(x=>x.UserName == name);
        }

    }
}
