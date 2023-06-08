using RAAMEN.Model;
using RAAMEN.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAAMEN.View
{
    public partial class TransactionDetail : System.Web.UI.Page
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
            int id = int.Parse(Request.QueryString["id"]);

            List<Detail> detail = RamenRepository.GetDetail();
            Header header =  RamenRepository.getHeaderBasedOnID(id);
            int detailid = detail.Count - 1;
            Raman ramen = RamenRepository.getRamenBasedOnID(detail[id-1].RamenId);
            User user = UserRepository.getUserBasedOnID(header.CustomerId);
            Meat meat = RamenRepository.getMeatBasedOnID(ramen.MeatId);

            orderid.Text = "Order ID: " + header.Id;
            ramenid.Text = "Ramen ID: " + detail[id - 1].RamenId;
            customerid.Text = "Customer ID: " + header.CustomerId;
            ramenname.Text = "Ramen Name: " + ramen.Name;
            ramenmeat.Text = "Ramen Meat: " + meat.name;
            ramenbroth.Text = "Broth: " + ramen.Broth;
            quantity.Text = "Quantity: " + detail[id - 1].Quantity;
            username.Text = "Customer username: " + user.Username;
            totalprice.Text = "Total Price: " + (detail[id - 1].Quantity * int.Parse(ramen.Price));


        }
    }
}