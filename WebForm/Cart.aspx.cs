using System;

namespace WebForm
{
    public partial class Cart : System.Web.UI.Page
    {
        OrderService.OrderServiceSoapClient order = new OrderService.OrderServiceSoapClient();
        public static string totalOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["isbn"] != null)
                {
                    string isbn = Request.QueryString["isbn"];
                    order.AddCart(isbn, Session["Username"].ToString(), "1");
                }

                totalOrder = ObjToVnd(order.TotalOrder(Session["Username"].ToString()));
                rptCart.DataSource = order.GetCartByUsername(Session["Username"].ToString());
                rptCart.DataBind();
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));

        protected void btnCreateOrder_Click(object sender, EventArgs e)
        {
            order.CreateOrder(Session["Username"].ToString());
            Response.Redirect("/MyOrders.aspx");
        }
    }
}