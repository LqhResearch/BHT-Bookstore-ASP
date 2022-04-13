using System;
using System.Collections.Generic;
using System.Data;

namespace BHT_Bookstore_ASP_NET.admin.categories
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
                pager = Pagination.Process("Categories", page, Content.RECORD_NUMBER_FOR_PAGE);

                ShowEdit();
                DeleteData();
                GetTable();
            }
        }

        #region This function
        private void ShowEdit()
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();

                DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Categories WHERE CategoryID = " + id);
                txtID_Edit.Text = dt.Rows[0]["CategoryID"].ToString();
                txtName_Edit.Text = dt.Rows[0]["CategoryName"].ToString();
            }
        }

        private void DeleteData()
        {
            if (Request.QueryString["del-id"] != null)
            {
                string id = Request.QueryString["del-id"].ToString();

                string sql = @"DELETE FROM Categories WHERE CategoryID = " + id;
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    lblMessage.Text = Content.SuccessDeleteMessage;
            }
        }

        private void GetTable()
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Categories ORDER BY CategoryID DESC OFFSET " + pager["StartIndex"] + " ROWS FETCH NEXT " + pager["PageSize"] + " ROWS ONLY");
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0) 
                lblList.Text = Content.RepeaterNoData;
        }
        #endregion

        protected void btnSubmit_Add_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Categories (CategoryName) VALUES (N'" + txtName_Add.Text + "')";
            if (SQLQuery.ExecuteNonQuery(sql) > 0)
                Response.Redirect("list.aspx");
        }

        protected void btnSubmit_Edit_Click(object sender, EventArgs e)
        {
            string sql = @"UPDATE Categories SET CategoryName = N'" + txtName_Edit.Text + "' WHERE CategoryID = " + txtID_Edit.Text;
            if (SQLQuery.ExecuteNonQuery(sql) > 0)
                Response.Redirect("list.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryName LIKE N'%" + txtSearch.Text + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0) 
                lblList.Text = Content.RepeaterNoData;
            lblPaginationDisable.CssClass = "d-none";
        }
    }
}