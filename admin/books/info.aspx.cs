using System;
using System.Data;

namespace BHT_Bookstore_ASP_NET.admin.books
{
    public partial class info : System.Web.UI.Page
    {
        public static string ISBN { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ISBN = Request.QueryString["show-id"];
                GetInfo();
            }
        }

        private void GetInfo()
        {
            string sql = "SELECT * FROM Books, Languages, Categories, Publishes WHERE Books.LanguageID = Languages.LanguageID AND Books.CategoryID = Categories.CategoryID AND Books.PublishID = Publishes.PublishID AND ISBN = '" + ISBN + "'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                txtBookInfo.Text = "ISBN: " + row["ISBN"];
                txtBookInfo.Text += "\nTên sách: " + row["Name"];
                txtBookInfo.Text += "\nMô tả: " + row["Description"];
                txtBookInfo.Text += "\nNăm xuất bản: " + row["PublishYear"];
                txtBookInfo.Text += "\nTrọng lượng: " + row["Weight"];
                txtBookInfo.Text += "\nKích thước: " + row["Size"];
                txtBookInfo.Text += "\nSố trang: " + row["PageNumber"];
                txtBookInfo.Text += "\nNgôn ngữ: " + row["LanguageName"];
                txtBookInfo.Text += "\nThể loại: " + row["CategoryName"];
                txtBookInfo.Text += "\nNhà xuất bản: " + row["PublishName"];

                imgThumbnail.ImageUrl = dt.Rows[0]["Thumbnail"].ToString();
            }

            string sql2 = "SELECT Authors.*, Role FROM Books, Composers, Authors WHERE Books.ISBN = Composers.ISBN AND Composers.AuthorID = Authors.AuthorID AND Books.ISBN = '" + ISBN + "'";
            DataTable dt2 = SQLQuery.ExecuteQuery(sql2);
            if (dt2.Rows.Count > 0)
            {
                rptList.DataSource = dt2;
                rptList.DataBind();
            }
        }
    }
}