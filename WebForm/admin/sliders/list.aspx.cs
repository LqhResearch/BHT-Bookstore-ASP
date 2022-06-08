using System;
using System.Data;
using System.IO;

namespace WebForm.admin.slider
{
    public partial class list : System.Web.UI.Page
    {
        SliderService.SliderServiceSoapClient slider = new SliderService.SliderServiceSoapClient();
        PaginationService.PaginationServiceSoapClient pagination = new PaginationService.PaginationServiceSoapClient();
        StatisticalService.StatisticalServiceSoapClient statistical = new StatisticalService.StatisticalServiceSoapClient();
        public static DataRow pager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Pagination
                int page = Request.QueryString["page"] != null ? Convert.ToInt32(Request.QueryString["page"]) : 1;
                pager = pagination.Process("Sliders", page, Content.RECORD_NUMBER_FOR_PAGE).Rows[0];
                if (Convert.ToInt32(pager["TotalItems"]) == 0)
                    lblPaginationDisable.Visible = false;

                // Edit
                if (Request.QueryString["edit-id"] != null)
                {
                    string id = Request.QueryString["edit-id"];

                    DataTable dt = slider.GetItemById(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtID_Edit.Text = row["SliderID"].ToString();
                        txtName_Edit.Text = row["SliderName"].ToString();
                        txtDesc_Edit.Text = row["Description"].ToString();
                        ddlActive_Edit.SelectedValue = row["Status"].ToString();
                    }
                }

                // Delete
                if (Request.QueryString["del-id"] != null)
                {
                    string id = Request.QueryString["del-id"];
                    lblMessage.Text = slider.Delete(id) ? Content.SuccessMsg : Content.ErrorMsg;
                }
                LoadData();

                // Statistical
                DataRow stat = statistical.CategoryStatistical().Rows[0];
                lblCountAll.Text = stat["CountAll"].ToString();
            }
        }

        private bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        public string UploadFile()
        {
            string fileName = "";
            if (Page.IsValid && fThumb_Add.HasFile && CheckFileType(fThumb_Add.FileName))
            {
                fileName = "/uploads/" + fThumb_Add.FileName;
                string filePath = MapPath(fileName);
                fThumb_Add.SaveAs(filePath);
            }
            if (Page.IsValid && fThumb_Edit.HasFile && CheckFileType(fThumb_Edit.FileName))
            {
                fileName = "/uploads/" + fThumb_Edit.FileName;
                string filePath = MapPath(fileName);
                fThumb_Edit.SaveAs(filePath);
            }
            return fileName;
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
            LoadRepeater(slider.GetTableWithPage(pager["StartIndex"].ToString()));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMessage.Text = slider.Add(txtName_Add.Text, txtDesc_Add.Text, UploadFile(), ddlActive_Add.SelectedValue) ? Content.SuccessMsg : Content.ErrorMsg;
            Response.Redirect("list.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = slider.Edit(txtID_Edit.Text, txtName_Edit.Text, txtDesc_Edit.Text, UploadFile(), ddlActive_Edit.SelectedValue) ? Content.SuccessMsg : Content.ErrorMsg;
            LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRepeater(slider.Search(txtSearch.Text));
        }
    }
}