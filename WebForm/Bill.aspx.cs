using System;
using System.Data;

namespace WebForm
{
    public partial class Bill : System.Web.UI.Page
    {
        OrderService.OrderServiceSoapClient order = new OrderService.OrderServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["order-id"] != null)
                {
                    string orderID = Request.QueryString["order-id"];
                    DataTable orderData = order.GetOrderBill(orderID);

                    lblOrderID.Text = orderData.Rows[0]["OrderID"].ToString();
                    lblCreatedAt.Text = FormatDate(orderData.Rows[0]["CreatedAt"]);
                    lblPaymentDate.Text = FormatDate(orderData.Rows[0]["PaymentDate"]);

                    lblName.Text = orderData.Rows[0]["Fullname"].ToString();
                    lblPhone.Text = orderData.Rows[0]["Phone"].ToString();
                    lblEmail.Text = orderData.Rows[0]["Email"].ToString();

                    rptList.DataSource = order.GetOrderDetailBill(orderID);
                    rptList.DataBind();

                    lblTotal.Text = ObjToVnd(orderData.Rows[0]["TotalMoney"]);
                    lblFinalTotal.Text = ObjToVnd(orderData.Rows[0]["TotalRevenue"]);
                }
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));

        public static string FormatDate(object obj) => obj.ToString() != "" ? Convert.ToDateTime(obj.ToString()).ToString("dd/MM/yyyy HH:mm:ss") : "";

    }
}