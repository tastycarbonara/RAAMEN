using RAAMEN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View
{
    public partial class HandleRamen : System.Web.UI.Page
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
            orders.DataSource = RamenRepository.getOrders();
            orders.DataBind();
        }

        protected void orders_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = orders.Rows[e.NewSelectedIndex];

            int id = int.Parse(row.Cells[1].Text.ToString());

            RamenRepository.UpdateRamenStatus(id);

            Response.Redirect("HandleRamen.aspx");
        }
    }
}