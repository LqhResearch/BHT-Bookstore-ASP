using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BHT_Bookstore_ASP_NET.admin.books
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
                pager = Pagination.Process("Books", page, Content.RECORD_NUMBER_FOR_PAGE);

                ShowEdit();
                DeleteData();
                GetTable();
                LoadDropdown();
            }
        }

        #region This function
        private void LoadDropdown()
        {
            ddlLanguageID_Add.DataSource = SQLQuery.ExecuteQuery("SELECT * FROM Languages");
            ddlLanguageID_Add.DataValueField = "LanguageID";
            ddlLanguageID_Add.DataTextField = "LanguageName";
            ddlLanguageID_Add.DataBind();

            ddlCategoryID_Add.DataSource = SQLQuery.ExecuteQuery("SELECT * FROM Categories");
            ddlCategoryID_Add.DataValueField = "CategoryID";
            ddlCategoryID_Add.DataTextField = "CategoryName";
            ddlCategoryID_Add.DataBind();

            ddlPublishID_Add.DataSource = SQLQuery.ExecuteQuery("SELECT * FROM Publishes");
            ddlPublishID_Add.DataValueField = "PublishID";
            ddlPublishID_Add.DataTextField = "PublishName";
            ddlPublishID_Add.DataBind();

            ddlLanguageID_Edit.DataSource = SQLQuery.ExecuteQuery("SELECT * FROM Languages");
            ddlLanguageID_Edit.DataValueField = "LanguageID";
            ddlLanguageID_Edit.DataTextField = "LanguageName";
            ddlLanguageID_Edit.DataBind();

            ddlCategoryID_Edit.DataSource = SQLQuery.ExecuteQuery("SELECT * FROM Categories");
            ddlCategoryID_Edit.DataValueField = "CategoryID";
            ddlCategoryID_Edit.DataTextField = "CategoryName";
            ddlCategoryID_Edit.DataBind();

            ddlPublishID_Edit.DataSource = SQLQuery.ExecuteQuery("SELECT * FROM Publishes");
            ddlPublishID_Edit.DataValueField = "PublishID";
            ddlPublishID_Edit.DataTextField = "PublishName";
            ddlPublishID_Edit.DataBind();
        }

        private void ShowEdit()
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();

                DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Books WHERE ISBN = " + id);
                txtID_Edit.Text = dt.Rows[0]["ISBN"].ToString();
                txtName_Edit.Text = dt.Rows[0]["BookTitle"].ToString();
                txtDescription_Edit.Text = dt.Rows[0]["Description"].ToString();
                ddlPublishYear_Edit.SelectedValue = dt.Rows[0]["PublishYear"].ToString();
                txtWeight_Edit.Text = dt.Rows[0]["Weight"].ToString();
                string[] sizes = dt.Rows[0]["Size"].ToString().Split('x');
                txtSizeWidth_Edit.Text = sizes[0];
                txtSizeHeight_Edit.Text = sizes[1];
                txtPageNumber_Edit.Text = dt.Rows[0]["PageNumber"].ToString();
                txtSalePrice_Edit.Text = dt.Rows[0]["Price"].ToString();
                ddlLanguageID_Edit.SelectedValue = dt.Rows[0]["LanguageID"].ToString();
                ddlCategoryID_Edit.SelectedValue = dt.Rows[0]["CategoryID"].ToString();
                ddlPublishID_Edit.SelectedValue = dt.Rows[0]["PublishID"].ToString();
            }
        }

        private void DeleteData()
        {
            if (Request.QueryString["del-id"] != null)
            {
                string id = Request.QueryString["del-id"].ToString();

                string sql = @"DELETE FROM Books WHERE ISBN = " + id;
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    lblMessage.Text = Content.SuccessDeleteMessage;
            }
        }

        private void GetTable()
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Books, Categories, Publishes WHERE Books.CategoryID = Categories.CategoryID AND Books.PublishID = Publishes.PublishID ORDER BY ISBN DESC OFFSET " + pager["StartIndex"] + " ROWS FETCH NEXT " + pager["PageSize"] + " ROWS ONLY");
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
        }

        #endregion
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

        protected void btnSubmit_Add_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && fThumbnail_Add.HasFile && CheckFileType(fThumbnail_Add.FileName))
            {
                string fileName = "/uploads/" + fThumbnail_Add.FileName;
                string filePath = MapPath(fileName);
                fThumbnail_Add.SaveAs(filePath);

                string sql = @"INSERT INTO Books (ISBN, BookTitle, Description, PublishYear, Weight, Size, PageNumber, Thumbnail, Price, LanguageID, CategoryID, PublishID) VALUES (N'" + txtID_Add.Text + "', N'" + txtName_Add.Text + "', N'" + txtDescription_Add.Text + "', " + ddlPublishYear_Add.SelectedValue + ", " + txtWeight_Add.Text + ", N'" + txtSizeWidth_Add.Text + "x" + txtSizeHeight_Add.Text + "', " + txtPageNumber_Add.Text + ", N'" + fileName + "', " + txtSalePrice_Add.Text + ", '" + ddlLanguageID_Add.SelectedValue + "', '" + ddlCategoryID_Add.SelectedValue + "', " + ddlPublishID_Add.SelectedValue + ")";
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    Response.Redirect("list.aspx");
            }
        }

        protected void btnSubmit_Edit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && fThumbnail_Edit.HasFile && CheckFileType(fThumbnail_Edit.FileName))
            {
                string fileName = "/uploads/" + fThumbnail_Edit.FileName;
                string filePath = MapPath(fileName);
                fThumbnail_Edit.SaveAs(filePath);

                string sql = @"UPDATE Books SET BookTitle = N'" + txtName_Edit.Text + "', Description = N'" + txtDescription_Edit.Text + "', PublishYear = " + ddlPublishID_Edit.Text + ", Weight = " + txtWeight_Edit.Text + ", Size = N'" + txtSizeWidth_Edit.Text + "x" + txtSizeHeight_Edit.Text + "', PageNumber = " + txtPageNumber_Edit.Text + ", Thumbnail = N'" + fileName + "', Price = " + txtSalePrice_Edit.Text + ", LanguageID = N'" + ddlLanguageID_Edit.SelectedValue + "', CategoryID = " + ddlCategoryID_Edit.SelectedValue + ", PublishID = " + ddlPublishID_Edit.SelectedValue + " WHERE ISBN = N'" + txtID_Edit.Text + "'";
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    Response.Redirect("list.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Books WHERE BookTitle LIKE N'%" + txtSearch.Text + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
            lblPaginationDisable.CssClass = "d-none";
        }
    }
}