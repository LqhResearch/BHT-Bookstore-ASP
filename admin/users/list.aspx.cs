using System;
using System.Collections.Generic;
using System.Data;

namespace BHT_Bookstore_ASP_NET.admin.users
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
                pager = Pagination.Process("Users", page, Content.RECORD_NUMBER_FOR_PAGE);

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
                DataTable dt2 = SQLQuery.ExecuteQuery("SELECT * FROM AccountTypes");
                ddlAccountType_Edit.DataSource = dt2;
                ddlAccountType_Edit.DataValueField = "AccountTypeID";
                ddlAccountType_Edit.DataTextField = "AccountTypeName";
                ddlAccountType_Edit.DataBind();

                DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Users WHERE UserName = N'" + id + "'");
                txtID_Edit.Text = dt.Rows[0]["UserName"].ToString();
                ddlStatus_Edit.SelectedValue = Convert.ToInt32(dt.Rows[0]["Status"]).ToString();
                ddlAccountType_Edit.SelectedValue = dt.Rows[0]["AccountTypeID"].ToString();
            }
        }

        private void DeleteData()
        {
            if (Request.QueryString["del-id"] != null)
            {
                string id = Request.QueryString["del-id"].ToString();

                string sql = @"DELETE FROM Users WHERE UserName = N'" + id + "'";
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    lblMessage.Text = Content.SuccessDeleteMessage;
            }
        }

        private void GetTable()
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Users, AccountTypes WHERE Users.AccountTypeID = AccountTypes.AccountTypeID ORDER BY CreatedAt DESC OFFSET " + pager["StartIndex"] + " ROWS FETCH NEXT " + pager["PageSize"] + " ROWS ONLY");
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
        }
        #endregion

        protected void btnSubmit_Edit_Click(object sender, EventArgs e)
        {
            string sql = @"UPDATE Users SET Status = " + ddlStatus_Edit.SelectedValue + ", AccountTypeID = " + ddlAccountType_Edit.SelectedValue + " WHERE UserName = N'" + txtID_Edit.Text + "'";
            if (SQLQuery.ExecuteNonQuery(sql) > 0)
                Response.Redirect("list.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Users WHERE Fullname LIKE N'%" + txtSearch.Text + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
            lblPaginationDisable.CssClass = "d-none";
        }
    }
}