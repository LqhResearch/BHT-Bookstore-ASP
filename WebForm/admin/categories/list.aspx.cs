using System;
using System.Data;

namespace WebForm.admin.categories
{
    public partial class list : System.Web.UI.Page
    {
        CategoryService.CategoryServiceSoapClient category = new CategoryService.CategoryServiceSoapClient();
        PaginationService.PaginationServiceSoapClient pagination = new PaginationService.PaginationServiceSoapClient();
        StatisticalService.StatisticalServiceSoapClient statistical = new StatisticalService.StatisticalServiceSoapClient();
        public static DataRow pager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Pagination
                int page = Request.QueryString["page"] != null ? Convert.ToInt32(Request.QueryString["page"]) : 1;
                pager = pagination.Process("Categories", page, Content.RECORD_NUMBER_FOR_PAGE).Rows[0];
                if (Convert.ToInt32(pager["TotalItems"]) == 0)
                    lblPaginationDisable.Visible = false;

                // Edit
                if (Request.QueryString["edit-id"] != null)
                {
                    string id = Request.QueryString["edit-id"];

                    DataTable dt = category.GetItemById(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtID_Edit.Text = row["CategoryID"].ToString();
                        txtName_Edit.Text = row["CategoryName"].ToString();
                        ddlParentID_Edit.SelectedValue = row["ParentID"].ToString();
                        ddlActive_Edit.SelectedValue = row["Active"].ToString();
                    }
                }

                // Delete
                if (Request.QueryString["del-id"] != null)
                {
                    string id = Request.QueryString["del-id"];
                    lblMessage.Text = category.Delete(id) ? Content.SuccessMsg : Content.ErrorMsg;
                }
                LoadData();

                // Statistical
                DataRow stat = statistical.CategoryStatistical().Rows[0];
                lblCountAll.Text = stat["CountAll"].ToString();
                lblCountParent.Text = stat["CountParent"].ToString();
                lblCountChild.Text = stat["CountChild"].ToString();
                lblCountActive.Text = stat["CountActive"].ToString();
            }
        }

        public void LoadRepeater(DataTable dt)
        {
            rptList.DataSource = dt;
            rptList.DataBind();

            if (dt.Rows.Count == 0)
            {
                lblNoData.Text = Content.RepeaterNoData;
                lblPaginationDisable.Visible = false;
            }
            else
            {
                lblNoData.Text = "";
                lblPaginationDisable.Visible = true;
            }
        }

        private void LoadData()
        {
            LoadRepeater(category.GetTableWithPage(pager["StartIndex"].ToString()));

            DataTable dt = category.GetTable();
            DataRow row = dt.NewRow();
            row["CategoryID"] = "0";
            row["CategoryName"] = "Danh mục gốc";
            dt.Rows.InsertAt(row, 0);

            ddlParentID_Add.DataSource = dt;
            ddlParentID_Add.DataValueField = "CategoryID";
            ddlParentID_Add.DataTextField = "CategoryName";
            ddlParentID_Add.DataBind();

            ddlParentID_Edit.DataSource = dt;
            ddlParentID_Edit.DataValueField = "CategoryID";
            ddlParentID_Edit.DataTextField = "CategoryName";
            ddlParentID_Edit.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text = category.Add(txtName_Add.Text, ddlParentID_Add.SelectedValue) ? Content.SuccessMsg : Content.ErrorMsg;
            Response.Redirect("list.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = category.Edit(txtID_Edit.Text, txtName_Edit.Text, ddlParentID_Edit.SelectedValue, ddlActive_Edit.Text) ? Content.SuccessMsg : Content.ErrorMsg;
            LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRepeater(category.Search(txtSearch.Text));
        }
    }
}