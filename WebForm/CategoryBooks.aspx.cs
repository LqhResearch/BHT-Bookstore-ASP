using System;

namespace WebForm
{
    public partial class CategoryBooks : System.Web.UI.Page
    {
        CategoryService.CategoryServiceSoapClient category = new CategoryService.CategoryServiceSoapClient();
        BookService.BookServiceSoapClient book = new BookService.BookServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryID = Request.QueryString["category-id"] != null ? Request.QueryString["category-id"] : "1";
                rptBookList.DataSource = book.GetTableByCategory(categoryID);
                rptBookList.DataBind();
                lblCategoryName.Text = category.GetItemById(categoryID).Rows[0]["CategoryName"].ToString();
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));
    }
}