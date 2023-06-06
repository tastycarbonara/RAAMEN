using RAAMEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository
{
    public class RamenRepository
    {
        static raamenEntities db = new raamenEntities();
        public static void insert(Raman ramen)
        {
            db.Ramen.Add(ramen);
            db.SaveChanges();
        }

        public static void update(int id, int MeatId, string name, string Broth, string Price)
        {
            Raman ramen = getRamenBasedOnID(id);
            ramen.MeatId = MeatId;
            ramen.Name = name;
            ramen.Broth = Broth;
            ramen.Price = Price;

            db.SaveChanges();
        }

        public static void deleteRamen(int id)
        {
            Raman ramen = getRamenBasedOnID(id);
            db.Ramen.Remove(ramen);
            db.SaveChanges();
        }

        public static Raman getRamenBasedOnID(int id)
        {
            return db.Ramen.Find(id);
        }

        public static List<Raman> getAllRamen()
        {
            return db.Ramen.ToList();
        }
    }
}