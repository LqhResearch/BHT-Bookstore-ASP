using System;
using System.Data;

namespace WebForm.admin.publishes
{
    public partial class list : System.Web.UI.Page
    {
        PublishService.PublishServiceSoapClient publish = new PublishService.PublishServiceSoapClient();
        PaginationService.PaginationServiceSoapClient pagination = new PaginationService.PaginationServiceSoapClient();
        StatisticalService.StatisticalServiceSoapClient statistical = new StatisticalService.StatisticalServiceSoapClient();
        public static DataRow pager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Pagination
                int page = Request.QueryString["page"] != null ? Convert.ToInt32(Request.QueryString["page"]) : 1;
                pager = pagination.Process("Publishes", page, Content.RECORD_NUMBER_FOR_PAGE).Rows[0];
                if (Convert.ToInt32(pager["TotalItems"]) == 0)
                    lblPaginationDisable.Visible = false;

                // Edit
                if (Request.QueryString["edit-id"] != null)
                {
                    string id = Request.QueryString["edit-id"];

                    DataTable dt = publish.GetItemById(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtID_Edit.Text = row["PublishID"].ToString();
                        txtName_Edit.Text = row["PublishName"].ToString();
                        txtPhone_Edit.Text = row["Phone"].ToString();
                        txtAddress_Edit.Text = row["Address"].ToString();
                        txtFax_Edit.Text = row["Fax"].ToString();
                    }
                }

                // Delete
                if (Request.QueryString["del-id"] != null)
                {
                    string id = Request.QueryString["del-id"];
                    lblMessage.Text = publish.Delete(id) ? Content.SuccessMsg : Content.ErrorMsg;
                }
                LoadData();

                // Statistical
                DataRow stat = statistical.PublishStatistical().Rows[0];
                lblCountAll.Text = stat["CountAll"].ToString();
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
            LoadRepeater(publish.GetTableWithPage(pager["StartIndex"].ToString()));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text = publish.Add(txtName_Add.Text, txtPhone_Add.Text, txtAddress_Add.Text, txtFax_Add.Text) ? Content.SuccessMsg : Content.ErrorMsg;
            Response.Redirect("list.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = publish.Edit(txtID_Edit.Text, txtName_Edit.Text, txtPhone_Edit.Text, txtAddress_Edit.Text, txtFax_Edit.Text) ? Content.SuccessMsg : Content.ErrorMsg;
            LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRepeater(publish.Search(txtSearch.Text));
        }
    }
}