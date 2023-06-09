using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View.Master_Site
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];

            if(cookie == null)
            {
                Response.Redirect("Login.aspx");
            }
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

        protected void history_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionHistory.aspx");
        }

        protected void report_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report2.aspx");
        }
    }
}