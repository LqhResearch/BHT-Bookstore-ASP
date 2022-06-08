using System;
using System.Data;

namespace WebForm
{
    public partial class BookDetails : System.Web.UI.Page
    {
        BookService.BookServiceSoapClient book = new BookService.BookServiceSoapClient();
        CommentService.CommentServiceSoapClient comment = new CommentService.CommentServiceSoapClient();
        public static string isbn = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["isbn"] != null)
                {
                    isbn = Request.QueryString["isbn"];
                    DataTable dt = book.GetItemById(isbn);
                    if (dt != null)
                    {
                        DataRow row = dt.Rows[0];
                        img.ImageUrl = row["Thumbnail"].ToString();
                        lblISBN.Text = row["ISBN"].ToString();
                        lblBookTitle.Text = row["BookTitle"].ToString();
                        lblPublishYear.Text = row["PublishYear"].ToString();
                        lblWeight.Text = row["Weight"].ToString() + " gam";
                        lblSize.Text = row["Size"].ToString() + " mm";
                        lblPageNumber.Text = row["PageNumber"].ToString();
                        lblISBN.Text = row["ISBN"].ToString();
                        lblPrice.Text = ObjToVnd(row["Price"]);
                        lblLanguage.Text = row["LanguageName"].ToString();
                        lblCategory.Text = row["CategoryName"].ToString();
                        lblPublish.Text = row["PublishName"].ToString();
                        lblDescription.Text = row["Description"].ToString();

                        rptComment.DataSource = comment.GetCommentAndRatingByISBN(isbn);
                        rptComment.DataBind();
                    }
                }
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));

        public static string FormatDate(object obj) => obj.ToString() != "" ? Convert.ToDateTime(obj.ToString()).ToString("dd/MM/yyyy") : "";

        protected void btnCommentSubmit_Click(object sender, EventArgs e)
        {
            bool ans1 = comment.AddComment(isbn, Session["Username"].ToString(), txtComment.Text, "0");
            bool ans2 = comment.AddRating(isbn, Session["Username"].ToString(), Rating1.CurrentRating.ToString());
            if (ans1 && ans2)
                Response.Redirect(Request.RawUrl);
        }

        public static string RatingStar(object val)
        {
            string str = "";
            int star = Convert.ToInt32(val);
            for (int i = 1; i <= 5; i++)
            {
                if (i <= star)
                    str += "<i class='fas fa-star yellow'></i>";
                else
                    str += "<i class='fas fa-star black'></i>";
            }
            return str;
        }
    }
}