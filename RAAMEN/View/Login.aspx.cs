using RAAMEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            raamenEntities1 db = new raamenEntities1();

            User user = (from u in db.Users
                         where u.Username.Equals(usernm.Text)
      && u.Password.Equals(passw.Text)
                         select u).FirstOrDefault();

            if (user == null)
            {
                status.Text = "Username" + usernm.Text + " doesn't exist";
                return;
            }

            HttpCookie cookie = new HttpCookie("ingfo");

            cookie["id"] = user.Id.ToString();
            cookie["user"] = user.Username;
            cookie["role"] = user.RoleId.ToString();

            Session["user_pass"] = user.Password;

            if (remember.Checked)
            {
                cookie.Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Response.Cookies["id"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["role"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["user_pass"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies.Add(cookie);


            if (cookie["role"].Equals("1") || cookie["role"].Equals("2"))
            {
                Response.Redirect("Home.aspx");
            }
            else if (cookie["role"].Equals("3"))
            {
                Response.Redirect("OrderRamen.aspx");
            }
        }

    }

       
}