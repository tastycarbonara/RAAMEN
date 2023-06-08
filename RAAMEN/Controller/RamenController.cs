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
            if (!name.Contains("Ramen"))
            {
                return "Name must end with Ramen";
            }
            else if ( MeatId == 0 )
            {
                return "Please select a meat";
            }
            else if (broth.Equals(""))
            {
                return "Please enter the broth";
            }
            else if(int.Parse(price) < 3000)
            {
                return "Price must be above 3000";
            }
            else
            {
                return RamenHandler.insertRamen(MeatId, name, broth, price);
            }

        }

        public static string updateRamen(int id, int MeatId, string name, string broth, string price)
        {
            if (!name.Contains("Ramen"))
            {
                return "Please enter a name";
            }
            else if (MeatId == 0)
            {
                return "Please select a meat";
            }
            else if (broth.Equals(""))
            {
                return "Please enter the broth";
            }
            else if (int.Parse(price) < 3000)
            {
                return "Price must be above 3000";
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