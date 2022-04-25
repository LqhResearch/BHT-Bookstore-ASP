using System;
using System.Collections.Generic;
using System.Data;

namespace BHT_Bookstore_ASP_NET.admin.orders
{
    public partial class list : System.Web.UI.Page
    {
        public static Dictionary<string, int> pager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set default properties
                int page = Request.QueryString["page"] != null ? Convert.ToInt32(Request.QueryString["page"]) : 1;
                pager = Pagination.Process("Orders", page, Content.RECORD_NUMBER_FOR_PAGE);

                Payment();
                GetTable();
            }
        }

        #region This function

        private void GetTable()
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Orders ORDER BY CreatedAt DESC OFFSET " + pager["StartIndex"] + " ROWS FETCH NEXT " + pager["PageSize"] + " ROWS ONLY");
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
        }

        private void Payment()
        {
            if (Request.QueryString["payment-id"] != null)
            {
                string id = Request.QueryString["payment-id"];
                string sql = "UPDATE Orders SET Status = 1 WHERE OrderID = '" + id + "'";
                SQLQuery.ExecuteNonQuery(sql);
            }
        }

        #endregion
    }
}