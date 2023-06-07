using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\raamen.mdf';Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework");
            String query = "select Id, CustomerId, Staffid, Date, Detail.RamenId, Detail.Quantity from Header INNER JOIN Detail ON Header.Id = Detail.HeaderId";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            transactions.DataSource = dr;
            transactions.DataBind();
            con.Close();

            HttpCookie cookie = Request.Cookies["ingfo"];
            if (cookie["role"].Equals("3"))
            {
                foreach (GridViewRow myrow in transactions.Rows)
                {
                    myrow.Visible = false;
                    if (myrow.Cells[1].Text == cookie["id"])
                    {
                        myrow.Visible = true;
                    }
                }
            }
        }

        protected void transactions_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = transactions.Rows[e.NewSelectedIndex];
            int id = int.Parse(row.Cells[1].Text);
            Response.Redirect("~/View/TransactionDetail.aspx?id=" + id);
        }
    }
}