using RAAMEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Factory
{
    public class UserFactory
    {
        public static User createUser(string username, string email, string gender, string password)
        {
            User user = new User();
            user.Username = username;
            user.Email = email;
            user.Gender = gender;
            user.Password = password;
            user.RoleId = 3;

            return user;
        }
    }
}