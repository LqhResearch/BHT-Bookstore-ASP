using System;

namespace BHT_Bookstore_ASP_NET
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddCart();

                rptSliders.DataSource = SQLQuery.ExecuteQuery("SELECT * FROM Sliders");
                rptSliders.DataBind();
                rptLastestBooks.DataSource = SQLQuery.ExecuteQuery("SELECT * FROM Books");
                rptLastestBooks.DataBind();
            }
        }

        private void AddCart()
        {
            if (Request.QueryString["cart-isbn"] != null)
            {
                string isbn = Request.QueryString["cart-isbn"];
                string sql = "INSERT INTO Carts (ISBN, UserName) VALUES ('" + isbn + "', N'" + Session["username"] + "')";
                SQLQuery.ExecuteQuery(sql);
            }
        }
    }
}