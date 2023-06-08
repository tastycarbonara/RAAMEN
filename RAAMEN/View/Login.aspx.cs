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
                status.Text = "Username " + usernm.Text + " doesn't exist or your password is wrong";
                return;
            }


            HttpCookie cookie = new HttpCookie("ingfo");
            Session["id"] = user.Id.ToString();
            Session["user"] = user.Username;
            Session["role"] = user.RoleId.ToString();

            Session["user_pass"] = user.Password;

            if (remember.Checked)
            {
                
                cookie["id"] = user.Id.ToString();
                cookie["user"] = user.Username;
                cookie["role"] = user.RoleId.ToString();

                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
            }

            status.Text = "login dengan username " + Session["user"] + " dan kode role " + Session["role"];

            Response.Redirect("Home.aspx");
            
            
        }

    }

       
}