using RAAMEN.Controller;
using RAAMEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];

            if (!string.IsNullOrEmpty(Page.MasterPageFile))
            {
                if (cookie["role"].Equals("1"))
                {
                    Page.MasterPageFile = "~/View/Master Site/Admin.master";
                }
                else if (cookie["role"].Equals("2"))
                {
                    Page.MasterPageFile = "~/View/Master Site/Staff.master";
                }
                else if (cookie["role"].Equals("3"))
                {
                    Page.MasterPageFile = "~/View/Master Site/Customer.master";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];
            User user = UserController.getUserBasedOnID(int.Parse(cookie["id"]));

            showUsername.Text = "Username: " + user.Username;
            showEmail.Text = "Email: " + user.Email;
            showGender.Text = "Gender: " + user.Gender;
            showPassword.Text = "Password: "+ user.Password;
        }

        protected void update_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];
            UserController.updateUser(int.Parse(cookie["id"]),usernm.Text, email.Text, gender.SelectedValue,
                pass.Text, confpass.Text);

            if (UserController.updateUser(int.Parse(cookie["id"]), usernm.Text, email.Text, gender.SelectedValue,
                pass.Text, confpass.Text) == "Please fill the boxes correctly")
            {
                status.Text = "Please fill the boxes correctly";
            }

            status.Text = "Success";

        }
    }
}