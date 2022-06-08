using System;

namespace WebForm
{
    public partial class MyOrders : System.Web.UI.Page
    {
        OrderService.OrderServiceSoapClient order = new OrderService.OrderServiceSoapClient();
        UserService.UserServiceSoapClient user = new UserService.UserServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["order-id"] != null && Request.QueryString["pay"] != null)
                {
                    string orderID = Request.QueryString["order-id"];
                    lblMessage.Text = order.PaymentOrder(Session["Username"].ToString(), orderID) ? "<div class='alert alert-success'>Thanh toán thành công</div>" : "<div class='alert alert-danger'>Số tiền trong ví bạn không đủ</div>";
                }

                lblMyMoney.Text = "Ví tiền của tôi: " + ObjToVnd(user.GetMoney(Session["Username"].ToString()));
                rptList.DataSource = order.GetOrderByUsername(Session["Username"].ToString());
                rptList.DataBind();
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));

        public static string FormatDate(object obj) => obj.ToString() != "" ? Convert.ToDateTime(obj.ToString()).ToString("dd/MM/yyyy HH:mm:ss") : "";
    }
}