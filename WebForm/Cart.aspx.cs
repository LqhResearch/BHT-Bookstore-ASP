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
                if (Request.QueryString["action"] != null)
                {
                    string isbn = Request.QueryString["isbn"];
                    string amount = Request.QueryString["amount"];
                    order.EditCart(isbn, Session["Username"].ToString(), amount);
                }
                else
                {
                    if (Request.QueryString["isbn"] != null)
                    {
                        string isbn = Request.QueryString["isbn"];
                        if (!order.AddCart(isbn, Session["Username"].ToString(), "1"))
                            lblMessage.Text = "<div class='alert alert-danger' role='alert'><strong>Lỗi!</strong> Sản phẩm đã thêm rồi.</div>";
                    }
                }

                if(Request.QueryString["del-isbn"] != null)
                {
                    string isbn = Request.QueryString["del-isbn"];
                    order.DeleteCart(isbn, Session["Username"].ToString());
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