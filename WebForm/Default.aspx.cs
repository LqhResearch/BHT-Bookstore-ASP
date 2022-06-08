using System;

namespace WebForm
{
    public partial class Default : System.Web.UI.Page
    {
        SliderService.SliderServiceSoapClient slider = new SliderService.SliderServiceSoapClient();
        BookService.BookServiceSoapClient book = new BookService.BookServiceSoapClient();
        CategoryService.CategoryServiceSoapClient category = new CategoryService.CategoryServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptSlider.DataSource = slider.GetTable();
                rptSlider.DataBind();
                rptLastedProduct.DataSource = book.GetLastedBooks();
                rptLastedProduct.DataBind();
                rptTopSellers.DataSource = book.GetTop3Books();
                rptTopSellers.DataBind();
                rptRecentlyViewed.DataSource = book.GetTop3Books();
                rptRecentlyViewed.DataBind();
                rptTopNew.DataSource = book.GetTop3Books();
                rptTopNew.DataBind();
            }
        }

        public static string ObjToVnd(object ojb) => Convert.ToInt32(ojb).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-vn"));
    }
}