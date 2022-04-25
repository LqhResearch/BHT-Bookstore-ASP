using System;
using System.Collections.Generic;
using System.Data;

namespace BHT_Bookstore_ASP_NET.admin.suppliers
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
                pager = Pagination.Process("Suppliers", page, Content.RECORD_NUMBER_FOR_PAGE);

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

                DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Suppliers WHERE SupplierID = " + id);
                txtID_Edit.Text = dt.Rows[0]["SupplierID"].ToString();
                txtName_Edit.Text = dt.Rows[0]["SupplierName"].ToString();
                txtPhone_Edit.Text = dt.Rows[0]["Phone"].ToString();
                txtAddress_Edit.Text = dt.Rows[0]["Address"].ToString();
                txtFax_Edit.Text = dt.Rows[0]["Fax"].ToString();
            }
        }

        private void DeleteData()
        {
            if (Request.QueryString["del-id"] != null)
            {
                string id = Request.QueryString["del-id"].ToString();

                string sql = @"DELETE FROM Suppliers WHERE SupplierID = " + id;
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    lblMessage.Text = Content.SuccessDeleteMessage;
            }
        }

        private void GetTable()
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Suppliers ORDER BY SupplierID DESC OFFSET " + pager["StartIndex"] + " ROWS FETCH NEXT " + pager["PageSize"] + " ROWS ONLY");
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
        }

        #endregion

        protected void btnSubmit_Add_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Suppliers (SupplierName, Phone, Address, Fax) VALUES (N'" + txtName_Add.Text + "', N'" + txtPhone_Add.Text + "', N'" + txtAddress_Add.Text + "', N'" + txtFax_Add.Text + "')";
            if (SQLQuery.ExecuteNonQuery(sql) > 0)
                Response.Redirect("list.aspx");
        }

        protected void btnSubmit_Edit_Click(object sender, EventArgs e)
        {
            string sql = @"UPDATE Suppliers SET SupplierName = N'" + txtName_Edit.Text + "', Phone = N'" + txtPhone_Edit.Text + "', Address = N'" + txtAddress_Edit.Text + "', Fax = N'" + txtFax_Edit.Text + "' WHERE SupplierID = " + txtID_Edit.Text;
            if (SQLQuery.ExecuteNonQuery(sql) > 0)
                Response.Redirect("list.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Suppliers WHERE SupplierName LIKE N'%" + txtSearch.Text + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
            lblPaginationDisable.CssClass = "d-none";
        }
    }
}