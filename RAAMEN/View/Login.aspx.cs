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
            raamenEntities db = new raamenEntities();

            User user = (from u in db.Users where u.Username.Equals(usernm.Text) 
                         && u.Password.Equals(passw.Text) select u).FirstOrDefault();

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

            cookie.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Add(cookie);

            Response.Redirect("Home.aspx");
        }
    }
}