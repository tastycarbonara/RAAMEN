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
    public partial class OrderRamen : System.Web.UI.Page
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

        protected void send_to_transaction()
        {
            HttpCookie cookie = Request.Cookies["ingfo"];
            raamenEntities1 db = new raamenEntities1();
            raamenEntities1 db2 = new raamenEntities1();
            int counter1 = 0;
            foreach (var items in db.Carts)
            {
                DateTime currentDateTime = DateTime.Now;           
                Header header = new Header();
                List<Cart> list = RamenRepository.getCart();

                if(cookie != null){
                    header.CustomerId = int.Parse(cookie["id"]);
                }
                else if(cookie == null)
                {
                    header.CustomerId = int.Parse(Session["id"].ToString());
                }

                
                header.Staffid = 2;
                header.Date = currentDateTime;
                db.Headers.Add(header);
                
            }
            db.SaveChanges();

            foreach (var item in db.Carts) {
                List<Header> list2 = RamenRepository.GetHeaders();
                List<Cart> list = RamenRepository.getCart();
                Detail detail = new Detail();
                int last = list2.Count - 1;
                detail.HeaderId = list2[last].Id;
                detail.RamenId = list[counter1].RamenId;
                detail.Quantity = list[counter1].Quantity;
                db2.Details.Add(detail);
                

                counter1 += 1;
            }
            db2.SaveChanges();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            order.DataSource = RamenRepository.getAllRamen();
            order.DataBind();

            cart.DataSource = RamenRepository.getCart();
            cart.DataBind();

            if (RamenRepository.getCart() == null)
            {
                buy.Enabled = false;
                clear.Enabled = false;
            }
        }

        protected void order_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = order.Rows[e.NewSelectedIndex];

            int id = int.Parse(row.Cells[1].Text.ToString());

            Raman ramen =  RamenRepository.getRamenBasedOnID(id);
            Cart cart = new Cart();
            cart.RamenId = ramen.Id;
            cart.RamenName = ramen.Name;
            cart.Quantity += 1;
            raamenEntities1 db = new raamenEntities1();
            db.Carts.Add(cart);
            db.SaveChanges();

            Response.Redirect("OrderRamen.aspx");
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            raamenEntities1 db = new raamenEntities1();
            foreach (var item in db.Carts)
            {
                db.Carts.Remove(item);
            }
            db.SaveChanges();

            Response.Redirect("OrderRamen.aspx");
        }

        protected void buy_Click(object sender, EventArgs e)
        {
            raamenEntities1 db = new raamenEntities1();
            
            int counter = 0;

            foreach(var item in db.Carts)
            {
                List<Cart> list = RamenRepository.getCart();
                Order order = new Order();
                order.RamenId = list[counter].RamenId;
                order.RamenName = list[counter].RamenName;
                order.Quantity = list[counter].Quantity;
                order.RamenStatus = "Unhandled";

                db.Orders.Add(order);
                counter += 1;
            }
            db.SaveChanges();

            send_to_transaction();

            foreach (var item in db.Carts)
            {
                db.Carts.Remove(item);
            }
            db.SaveChanges();
            Response.Redirect("OrderRamen.aspx");
        }
    }
}