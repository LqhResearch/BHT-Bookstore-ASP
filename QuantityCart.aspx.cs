using System;

namespace BHT_Bookstore_ASP_NET
{
    public partial class QuntityCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cart-id"] != null)
                {
                    string cartID = Request.QueryString["cart-id"];
                    string sql = "SELECT Amount FROM Carts WHERE ISBN = '" + cartID + "' AND Username = N'" + Session["username"] + "'";
                    txtAmount.Text = SQLQuery.ExecuteScalar(sql).ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cartID = Request.QueryString["cart-id"];
            string sql = "UPDATE Carts SET Amount = " + txtAmount.Text + " WHERE ISBN = '" + cartID + "' AND Username = N'" + Session["username"] + "'";
            SQLQuery.ExecuteNonQuery(sql);
            Response.Redirect("/Carts.aspx");
        }
    }
}