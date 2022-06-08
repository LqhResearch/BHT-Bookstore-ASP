using System;

namespace WebForm
{
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        CategoryService.CategoryServiceSoapClient category = new CategoryService.CategoryServiceSoapClient();
        OrderService.OrderServiceSoapClient order = new OrderService.OrderServiceSoapClient();
        public static string totalOrder = "";
        public static string countOrder = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Session["Role"]) == 3)
                {
                    totalOrder = ObjToVnd(order.TotalOrder(Session["Username"].ToString()));
                    countOrder = Convert.ToString(order.CountOrder(Session["Username"].ToString()));
                }

                rptParentCategories.DataSource = category.GetParentCategories();
                rptParentCategories.DataBind();
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));
    }
}