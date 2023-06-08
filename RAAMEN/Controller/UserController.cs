using RAAMEN.Handler;
using RAAMEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Controller
{
    public class UserController
    {
        public static string insertUser(string username, string email, string gender, string password, string confpass)
        {
            if(username.Length>15 && username.Length<5)
            {
                return "Username max 15 characters and min 5 characters";
            }
            else if (email.EndsWith(".com") == false)
            {
                return "Email must end with .com";
            }
            else if (gender == null)
            {
                return "Please enter your gender";
            }
            else if(confpass.Equals(password) == false)
            {
                return "Confirm Password doesn't match Password";
            }
            else
            {
                return UserHandler.insertUser(username, email, gender, password);
            }
            
        }

        public static string updateUser(int id, string username, string email, string gender, string password, string confpass)
        {
            if (username.Length > 15 && username.Length < 5)
            {
                return "Username max 15 characters and min 5 characters";
            }
            else if (email.EndsWith(".com") == false)
            {
                return "Email must end with .com";
            }
            else if (gender == null)
            {
                return "Please enter your gender";
            }
            else if (confpass.Equals(password) == false)
            {
                return "Confirm Password doesn't match Password";
            }
            else
            {
                return UserHandler.updateUser(id, username, email, gender, password);
            }
            
        }

        public static User getUserBasedOnID(int id)
        {
            return UserHandler.getUserBasedOnID(id);
        }

        public static List<User> getAllUser()
        {
            return UserHandler.getAllUser();
        }
    }
}