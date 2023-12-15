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

        public string UserName
        {
            get { return UserName; }
            set
            {
                if (value != null)
                {
                    UserName = value;
                }
                else
                {
                    throw new ArgumentNullException("username can't be null");
                }
            }
        }


        public string Password
        {
            get { return Password; }
            set
            {
                if (value != null)
                {
                    Password = value;
                }
                else
                {
                    throw new ArgumentNullException("password can't be null");
                }
            }
        }

        public Role Role { get; set; }

        public User()
        {

        }

        public User(int idVal, string username, string password, Role role)
        {
            Id = idVal;
            UserName = username;
            Password = password;
            Role = role;
        }

        public void AddNewUser(int id, string username, string password, Role role, FileManager<User> fileManager)
        {
            User user = new User(id, username, password, role);
            fileManager.Add(user);




        }

        public int LogIn()
        {

        }

    }
}
