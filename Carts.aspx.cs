using System;
using System.Data;

namespace BHT_Bookstore_ASP_NET
{
    public partial class Carts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["del-cart-id"] != null)
                {
                    string cartID = Request.QueryString["del-cart-id"];
                    SQLQuery.ExecuteNonQuery("DELETE FROM Carts WHERE ISBN = N'" + cartID + "' AND Username = '" + Session["username"] + "'");
                }

                string sql = "SELECT *, Carts.ISBN AS CartsISBN FROM Carts, Books WHERE Books.ISBN = Carts.ISBN AND Username = N'" + Session["username"] + "'";
                rptCarts.DataSource = SQLQuery.ExecuteQuery(sql);
                rptCarts.DataBind();
            }
        }

        private string CreateOrderID()
        {
            Random rd = new Random();
            string str = "BHT";
            for (int i = 1; i < 8; i++)
                str += rd.Next(0, 9);
            return str;
        }

        public static string TotalMoneyCarts(object username)
        {
            string sql = "SELECT SUM(Price * Amount) FROM Carts, Books WHERE Carts.ISBN = Books.ISBN AND Username = '" + username + "'";
            return SQLQuery.ExecuteScalar(sql).ToString();
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Carts WHERE Username = '" + Session["username"] + "'");

            // Tạo đơn hàng mới
            string orderID = CreateOrderID();
            string sql = "INSERT INTO Orders VALUES ('" + orderID + "', " + TotalMoneyCarts(Session["username"]) + ", " + TotalMoneyCarts(Session["username"]) + ", 0, NULL, GETDATE(), N'" + Session["username"] + "')";
            SQLQuery.ExecuteNonQuery(sql);

            // Thêm giỏ hàng vào chi tiết đơn hàng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql = "INSERT INTO OrderDetails (ISBN, OrderID, Amount) VALUES ('" + dt.Rows[i]["ISBN"] + "', '" + orderID + "', " + dt.Rows[i]["Amount"] + ")";
                SQLQuery.ExecuteNonQuery(sql);
            }

            // Xoá sản phẩm trong giỏ hàng
            sql = "DELETE FROM Carts WHERE Username = '" + Session["username"] + "'";
            SQLQuery.ExecuteNonQuery(sql);

            Response.Redirect("/Carts.aspx");
        }
    }
}