using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Factory
{
    public class RamenFactory
    {
        public static Raman createRamen(int MeatId, string name, string broth, string price)
        {
            Raman ramen = new Raman();
            ramen.MeatId = MeatId;
            ramen.Name = name;
            ramen.Broth = broth;
            ramen.Price = price;

            return ramen;
        }
    }
}