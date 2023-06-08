using RAAMEN.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regis_Click(object sender, EventArgs e)
        {
            status.Text = UserController.insertUser(usernm.Text, email.Text, gender.SelectedValue, 
                pass.Text, confpass.Text);
        }
    }
}