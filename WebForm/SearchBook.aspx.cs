using System;
using System.Data;

namespace WebForm
{
    public partial class SearchBook : System.Web.UI.Page
    {
        BookService.BookServiceSoapClient book = new BookService.BookServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["keyword"] != null)
                {
                    string keyword = Request.QueryString["keyword"];
                    DataTable dt = book.Search(keyword);

                    if (dt.Rows.Count > 0)
                    {
                        lblKeyword.Text = "Từ khóa '" + keyword + "' có " + dt.Rows.Count + " kết quả phù hợp";
                        rptBookList.DataSource = dt;
                        rptBookList.DataBind();
                    }
                    else
                    {
                        lblKeyword.Text = "Không có sách nào phù hợp với từ khóa '" + keyword + "'";
                    }
                }
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));

    }
}