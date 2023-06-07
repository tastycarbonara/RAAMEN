using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Master_Site
{
    public partial class Staff : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];
            if (cookie == null)
            {
                logout.Visible = false;
                Response.Redirect("Login.aspx");
            }
        }
        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];

            cookie.Expires = DateTime.Now.AddDays(-1);

            Response.Cookies.Add(cookie);
            Response.Redirect("Login.aspx");
        }

        protected void profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void ManageRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamen.aspx");
        }

        protected void queue_Click(object sender, EventArgs e)
        {
            Response.Redirect("HandleRamen.aspx");
        }
    }
}