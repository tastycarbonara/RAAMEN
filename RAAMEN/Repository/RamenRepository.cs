using RAAMEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Repository
{
    public class RamenRepository
    {
        static raamenEntities1 db = new raamenEntities1();
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

        public static Cart getCartBasedOnID(int id)
        {
            return db.Carts.Find(id);
        }

        public static Order getOrderBasedOnID(int id)
        {
            return db.Orders.Find(id);
        }

        public static List<Raman> getAllRamen()
        {
            return db.Ramen.ToList();
        }

        public static List<Cart> getCart()
        {
            return db.Carts.ToList();
        }

        public static List<Order> getOrders()
        {
            return db.Orders.ToList();
        }

        public static List<Header> GetHeaders()
        {
            return db.Headers.ToList();
        }

        public static void UpdateRamenStatus(int id)
        {
            Order order = getOrderBasedOnID(id);
            order.RamenStatus = "Handled";

            db.SaveChanges();
        }
    }
}