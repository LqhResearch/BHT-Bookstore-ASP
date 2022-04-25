using System;
using System.Collections.Generic;
using System.Data;

namespace BHT_Bookstore_ASP_NET.admin.authors
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
                pager = Pagination.Process("Authors", page, Content.RECORD_NUMBER_FOR_PAGE);

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

                DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Authors WHERE AuthorID = " + id);
                txtID_Edit.Text = dt.Rows[0]["AuthorID"].ToString();
                txtName_Edit.Text = dt.Rows[0]["AuthorName"].ToString();
                txtContact_Edit.Text = dt.Rows[0]["Contact"].ToString();
            }
        }

        private void DeleteData()
        {
            if (Request.QueryString["del-id"] != null)
            {
                string id = Request.QueryString["del-id"].ToString();

                string sql = @"DELETE FROM Authors WHERE AuthorID = " + id;
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    lblMessage.Text = Content.SuccessDeleteMessage;
            }
        }

        private void GetTable()
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Authors ORDER BY AuthorID DESC OFFSET " + pager["StartIndex"] + " ROWS FETCH NEXT " + pager["PageSize"] + " ROWS ONLY");
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
        }

        #endregion

        protected void btnSubmit_Add_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Authors (AuthorName, Contact) VALUES (N'" + txtName_Add.Text + "', N'" + txtContact_Add.Text + "')";
            if (SQLQuery.ExecuteNonQuery(sql) > 0)
                Response.Redirect("list.aspx");
        }

        protected void btnSubmit_Edit_Click(object sender, EventArgs e)
        {
            string sql = @"UPDATE Authors SET AuthorName = N'" + txtName_Edit.Text + "', Contact = N'" + txtContact_Edit.Text + "' WHERE AuthorID = " + txtID_Edit.Text;
            if (SQLQuery.ExecuteNonQuery(sql) > 0)
                Response.Redirect("list.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Authors WHERE AuthorName LIKE N'%" + txtSearch.Text + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
            lblPaginationDisable.CssClass = "d-none";
        }
    }
}