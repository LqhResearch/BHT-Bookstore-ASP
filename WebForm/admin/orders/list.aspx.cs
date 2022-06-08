using System;
using System.Data;

namespace WebForm.admin.orders
{
    public partial class list : System.Web.UI.Page
    {
        OrderService.OrderServiceSoapClient order = new OrderService.OrderServiceSoapClient();
        StatisticalService.StatisticalServiceSoapClient statistical = new StatisticalService.StatisticalServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRepeater(order.GetOrder());

                // Statistical
                DataRow stat = statistical.OrderStatistical().Rows[0];
                lblCountAll.Text = stat["CountAll"].ToString();
                lblDelivered.Text = stat["CountDelivered"].ToString();
                lblNoDelivered.Text = stat["CountNoDelivered"].ToString();
                lblMonthProceeds.Text = ObjToVnd(stat["MonthProceeds"]);
            }
        }

        public void LoadRepeater(DataTable dt)
        {
            rptList.DataSource = dt;
            rptList.DataBind();

            if (dt.Rows.Count == 0)
            {
                lblNoData.Text = Content.RepeaterNoData;
            }
            else
            {
                lblNoData.Text = "";
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));

        public static string FormatDate(object obj) => obj.ToString() != "" ? Convert.ToDateTime(obj.ToString()).ToString("dd/MM/yyyy HH:mm:ss") : "";

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRepeater(order.Search(txtSearch.Text));
        }
    }
}