using System;
using System.Data;

namespace WebForm.admin.users
{
    public partial class list : System.Web.UI.Page
    {
        UserService.UserServiceSoapClient user = new UserService.UserServiceSoapClient();
        PaginationService.PaginationServiceSoapClient pagination = new PaginationService.PaginationServiceSoapClient();
        StatisticalService.StatisticalServiceSoapClient statistical = new StatisticalService.StatisticalServiceSoapClient();
        public static DataRow pager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Pagination
                int page = Request.QueryString["page"] != null ? Convert.ToInt32(Request.QueryString["page"]) : 1;
                pager = pagination.Process("Users", page, Content.RECORD_NUMBER_FOR_PAGE).Rows[0];
                if (Convert.ToInt32(pager["TotalItems"]) == 0)
                    lblPaginationDisable.Visible = false;

                // Edit
                if (Request.QueryString["edit-id"] != null)
                {
                    string id = Request.QueryString["edit-id"];

                    DataTable dt = user.GetItemById(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtID_Edit.Text = row["Username"].ToString();
                        ddlAccountTypeID_Edit.SelectedValue = row["AccountTypeID"].ToString();
                        ddlStatus_Edit.SelectedValue = row["Status"].ToString();
                    }
                }

                // Delete
                if (Request.QueryString["del-id"] != null)
                {
                    string id = Request.QueryString["del-id"];
                    lblMessage.Text = user.Delete(id) ? Content.SuccessMsg : Content.ErrorMsg;
                }

                // Money
                if (Request.QueryString["coin-id"] != null)
                {
                    string id = Request.QueryString["coin-id"];

                    DataTable dt = user.GetItemById(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtID_Money.Text = row["Username"].ToString();
                        txtValue_Money.Text = row["Money"].ToString();
                    }
                }
                LoadData();

                // Statistical
                DataRow stat = statistical.UserStatistical().Rows[0];
                lblCountAll.Text = stat["CountAll"].ToString();
                lblCountAdmin.Text = stat["CountAdmin"].ToString();
                lblCountCustomer.Text = stat["CountCustomer"].ToString();
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
            LoadRepeater(user.GetTableWithPage(pager["StartIndex"].ToString()));

            ddlAccountTypeID_Edit.DataSource = user.GetAccountTypeTable();
            ddlAccountTypeID_Edit.DataValueField = "AccountTypeID";
            ddlAccountTypeID_Edit.DataTextField = "AccountTypeName";
            ddlAccountTypeID_Edit.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = user.Edit(txtID_Edit.Text, ddlStatus_Edit.SelectedValue, ddlAccountTypeID_Edit.SelectedValue) ? Content.SuccessMsg : Content.ErrorMsg;
            LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRepeater(user.Search(txtSearch.Text));
        }
        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));

        protected void btnMoney_Click(object sender, EventArgs e)
        {
            user.UpdateMoney(txtID_Money.Text, txtValue_Money.Text);
            LoadData();
        }
    }
}