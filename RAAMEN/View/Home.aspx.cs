using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];
            if (cookie == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                welcome.Text = "Welcome, " + cookie["user"];
            }
            
        }
    }
}