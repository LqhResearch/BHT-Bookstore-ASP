using System;
using System.Data;
using System.IO;

namespace WebForm.admin.books
{
    public partial class list : System.Web.UI.Page
    {
        BookService.BookServiceSoapClient book = new BookService.BookServiceSoapClient();
        CategoryService.CategoryServiceSoapClient category = new CategoryService.CategoryServiceSoapClient();
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
                pager = pagination.Process("Books", page, Content.RECORD_NUMBER_FOR_PAGE).Rows[0];
                if (Convert.ToInt32(pager["TotalItems"]) == 0)
                    lblPaginationDisable.Visible = false;

                // Edit
                if (Request.QueryString["edit-id"] != null)
                {
                    string id = Request.QueryString["edit-id"];

                    DataTable dt = book.GetItemById(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtISBN_Edit.Text = row["ISBN"].ToString();
                        txtName_Edit.Text = row["BookTitle"].ToString();
                        txtDesc_Edit.Text = row["Description"].ToString();
                        txtPublishYear_Edit.Text = row["PublishYear"].ToString();
                        txtWeight_Edit.Text = row["Weight"].ToString();
                        string[] size = row["Size"].ToString().Split('x');
                        txtSize_Width_Edit.Text = size[0];
                        txtSize_Height_Edit.Text = size[1];
                        txtPageNumber_Edit.Text = row["PageNumber"].ToString();
                        txtPrice_Edit.Text = row["Price"].ToString();
                        ddlLanguageID_Edit.SelectedValue = row["LanguageID"].ToString();
                        ddlCategoryID_Edit.SelectedValue = row["CategoryID"].ToString();
                        ddlPublishID_Edit.SelectedValue = row["PublishID"].ToString();
                    }
                }

                // Delete
                if (Request.QueryString["del-id"] != null)
                {
                    string id = Request.QueryString["del-id"];
                    lblMessage.Text = book.Delete(id) ? Content.SuccessMsg : Content.ErrorMsg;
                }
                LoadData();

                // Statistical
                DataRow stat = statistical.BookStatistical().Rows[0];
                lblCountAll.Text = stat["CountAll"].ToString();
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));

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
            LoadRepeater(book.GetTableWithPage(pager["StartIndex"].ToString()));

            ddlLanguageID_Add.DataSource = book.GetLanguageTable();
            ddlLanguageID_Add.DataValueField = "LanguageID";
            ddlLanguageID_Add.DataTextField = "LanguageName";
            ddlLanguageID_Add.DataBind();
            ddlLanguageID_Add.SelectedValue = "vi";
            ddlCategoryID_Add.DataSource = category.GetTable();
            ddlCategoryID_Add.DataValueField = "CategoryID";
            ddlCategoryID_Add.DataTextField = "CategoryName";
            ddlCategoryID_Add.DataBind();
            ddlPublishID_Add.DataSource = publish.GetTable();
            ddlPublishID_Add.DataValueField = "PublishID";
            ddlPublishID_Add.DataTextField = "PublishName";
            ddlPublishID_Add.DataBind();

            ddlLanguageID_Edit.DataSource = book.GetLanguageTable();
            ddlLanguageID_Edit.DataValueField = "LanguageID";
            ddlLanguageID_Edit.DataTextField = "LanguageName";
            ddlLanguageID_Edit.DataBind();
            ddlCategoryID_Edit.DataSource = category.GetTable();
            ddlCategoryID_Edit.DataValueField = "CategoryID";
            ddlCategoryID_Edit.DataTextField = "CategoryName";
            ddlCategoryID_Edit.DataBind();
            ddlPublishID_Edit.DataSource = publish.GetTable();
            ddlPublishID_Edit.DataValueField = "PublishID";
            ddlPublishID_Edit.DataTextField = "PublishName";
            ddlPublishID_Edit.DataBind();
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
            if (Page.IsValid && fThumbnail_Add.HasFile && CheckFileType(fThumbnail_Add.FileName))
            {
                fileName = "/uploads/" + fThumbnail_Add.FileName;
                string filePath = MapPath(fileName);
                fThumbnail_Add.SaveAs(filePath);
            }
            if (Page.IsValid && fThumbnail_Edit.HasFile && CheckFileType(fThumbnail_Edit.FileName))
            {
                fileName = "/uploads/" + fThumbnail_Edit.FileName;
                string filePath = MapPath(fileName);
                fThumbnail_Edit.SaveAs(filePath);
            }
            return fileName;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string size = txtSize_Width_Add.Text + "x" + txtSize_Height_Add.Text;
            lblMessage.Text = book.Add(txtISBN_Add.Text, txtName_Add.Text, txtDesc_Add.Text, txtPublishYear_Add.Text, txtWeight_Add.Text, size, txtPageNumber_Add.Text, UploadFile(), ddlLanguageID_Add.Text, txtPrice_Add.Text, "0", "0", ddlCategoryID_Add.Text, ddlPublishID_Add.Text) ? Content.SuccessMsg : Content.ErrorMsg;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string size = txtSize_Width_Edit.Text + "x" + txtSize_Height_Edit.Text;
            lblMessage.Text = book.Edit(txtISBN_Edit.Text, txtName_Edit.Text, txtDesc_Edit.Text, txtPublishYear_Edit.Text, txtWeight_Edit.Text, size, txtPageNumber_Edit.Text, UploadFile(), ddlLanguageID_Edit.Text, txtPrice_Edit.Text, "0", "0", ddlCategoryID_Edit.Text, ddlPublishID_Edit.Text) ? Content.SuccessMsg : Content.ErrorMsg;
            LoadData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRepeater(book.Search(txtSearch.Text));
        }
    }
}