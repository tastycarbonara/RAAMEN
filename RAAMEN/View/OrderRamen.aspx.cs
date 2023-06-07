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

        protected void send_to_transaction()
        {
            HttpCookie cookie = Request.Cookies["ingfo"];
            raamenEntities1 db = new raamenEntities1();
            raamenEntities1 db2 = new raamenEntities1();
            int counter = 0;
            foreach (var items in db.Carts)
            {
                DateTime currentDateTime = DateTime.Now;           
                Header header = new Header();
                List<Cart> list = RamenRepository.getCart();

                header.CustomerId = int.Parse(cookie["id"]);
                header.Staffid = 2;
                header.Date = currentDateTime;
                db.Headers.Add(header);
                
            }
            db.SaveChanges();

            foreach (var item in db.Headers) {
                List<Header> list2 = RamenRepository.GetHeaders();
                List<Cart> list = RamenRepository.getCart();
                Detail detail = new Detail();
                detail.HeaderId = list2[counter].Id;
                detail.RamenId = list[counter].RamenId;
                detail.Quantity = list[counter].Quantity;
                db2.Details.Add(detail);
                

                counter += 1;
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