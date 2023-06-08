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
    public partial class UpdateRamen : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["ingfo"];

            if (!string.IsNullOrEmpty(Page.MasterPageFile))
            {
                if (cookie == null)
                {
                    if (Session["role"].Equals("1"))
                    {
                        Page.MasterPageFile = "~/View/Master Site/Admin.master";
                    }
                    else if (Session["role"].Equals("2"))
                    {
                        Page.MasterPageFile = "~/View/Master Site/Staff.master";
                    }
                    else if (Session["role"].Equals("3"))
                    {
                        Page.MasterPageFile = "~/View/Master Site/Customer.master";
                    }
                    else if (Session["role"] == null)
                    {
                        Response.Redirect("Login.aspx");
                    }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                Raman ramen = RamenController.getRamenBasedOnID(id);
                name.Text = "Ramen Name: " + ramen.Name;
                meat.Text = "Meat ID: " + ramen.MeatId.ToString();
                broth.Text = "Broth: " + ramen.Broth;
                price.Text = "Price: " + ramen.Price;
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            status.Text = RamenController.updateRamen(id, int.Parse(meat_inp.SelectedValue), name_inp.Text,  broth_inp.Text, price_inp.Text);
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamen.aspx");
        }
    }
}