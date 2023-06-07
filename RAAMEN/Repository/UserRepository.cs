using RAAMEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository
{
    public class UserRepository
    {
        static raamenEntities1 db = new raamenEntities1();

        public static void insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static void update(int id, string username, string email, string gender, string password)
        {
            User user = getUserBasedOnID(id);
            user.Username = username;
            user.Email = email;
            user.Gender = gender;
            user.Password = password;
            db.SaveChanges();
        }

        public static User getUserBasedOnID(int id)
        {
            return db.Users.Find(id);
        }

        public static List<User> getAllUser()
        {
            return db.Users.ToList();
        }
    }
}