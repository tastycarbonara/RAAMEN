using RAAMEN.Handler;
using RAAMEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAAMEN.Controller
{
    public class RamenController
    {
        public static string insertRamen(int MeatId, string name, string broth, string price)
        {
            if (!name.Contains("Ramen") || MeatId==0 || broth.Equals("") || price.Equals(""))
            {
                return "Please fill the boxes correctly";
            }
            else
            {
                return RamenHandler.insertRamen(MeatId, name, broth, price);
            }

        }

        public static string updateRamen(int id, int MeatId, string name, string broth, string price)
        {
            if (!name.Contains("Ramen") || MeatId == 0 || broth.Equals("") || price.Equals(""))
            {
                return "Please fill the boxes correctly";
            }
            else
            {
                return RamenHandler.updateRamen(id,MeatId, name, broth, price);
            }

        }

        public static Raman getRamenBasedOnID(int id)
        {
            return RamenHandler.getRamenBasedOnID(id);
        }

        public static List<Raman> getAllRamen()
        {
            return RamenHandler.getAllRamen();
        }
    }
}