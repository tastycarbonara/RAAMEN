using RAAMEN.Factory;
using RAAMEN.Model;
using RAAMEN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Handler
{
    public class RamenHandler
    {
        public static string insertRamen(int MeatId, string name, string broth, string price)
        {
            Raman ramen = RamenFactory.createRamen(MeatId, name, broth, price);
            RamenRepository.insert(ramen);

            return "Success";
        }

        public static string updateRamen(int id, int MeatId, string name, string Broth, string Price)
        {
            RamenRepository.update(id, MeatId, name, Broth, Price);
            return "Success";
        }

        public static Raman getRamenBasedOnID(int id)
        {
            return RamenRepository.getRamenBasedOnID(id);
        }

        public static List<Raman> getAllRamen()
        {
            return RamenRepository.getAllRamen();
        }
    }
}