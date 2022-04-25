using System;

namespace BHT_Bookstore_ASP_NET
{
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public static string NumberItemsCarts(string username)
        {
            string sql = "SELECT count(*) FROM Carts WHERE Username = '" + username + "'";
            return SQLQuery.ExecuteScalar(sql).ToString();
        }

        public static string TotalMoneyCarts(string username)
        {
            string sql = "SELECT SUM(Price * Amount) FROM Carts, Books WHERE Carts.ISBN = Books.ISBN AND Username = '" + username + "'";
            return SQLQuery.ExecuteScalar(sql).ToString();
        }
    }
}