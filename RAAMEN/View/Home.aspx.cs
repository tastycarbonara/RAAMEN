using RAAMEN.Repository;
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
            else if(cookie!=null)
            {
                welcome.Text = "Welcome, " + cookie["user"];
                if (cookie["role"].Equals("1"))
                {
                    role.Text = "Your role is Admin";
                }
                else if (cookie["role"].Equals("2"))
                {
                    role.Text = "Your role is Staff";
                }
                else if (cookie["role"].Equals("3"))
                {
                    Response.Redirect("OrderRamen.aspx");
                }
            }


            gv.DataSource = UserRepository.getAllUser();
            gv.DataBind();

            if (cookie["role"].Equals("2"))
            {
                foreach (GridViewRow myrow in gv.Rows)
                {
                    myrow.Visible = false;
                    if (myrow.Cells[1].Text == "3")
                    {
                        myrow.Visible = true;
                    }
                }
            }

        }
        protected override void OnPreInit(EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];

            if (!string.IsNullOrEmpty(Page.MasterPageFile))
            {
                if (cookie == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (cookie["role"].Equals("1"))
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

    }
}