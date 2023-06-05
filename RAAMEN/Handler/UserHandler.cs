using RAAMEN.Factory;
using RAAMEN.Model;
using RAAMEN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Handler
{
    public class UserHandler
    {
        public static string insertUser(string username, string email, string gender, string password)
        {
            User user = UserFactory.createUser( username, email, gender, password);
            UserRepository.insert(user);

            return "Success";
        }

        public static string updateUser(int id, string username, string email, string gender, string password)
        {
            UserRepository.update(id, username, email, gender, password);
            return "Success";
        }

        public static User getUserBasedOnID(int id)
        {
            return UserRepository.getUserBasedOnID(id);
        }

        public static List<User> getAllUser()
        {
            return UserRepository.getAllUser();
        }
    }
}