using System;
using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class OrderService : System.Web.Services.WebService
    {
        /// <summary>
        /// Carts
        /// </summary>
        [WebMethod]
        public DataTable GetCartByUsername(string username)
        {
            string sql = "SELECT Books.ISBN, BookTitle, Thumbnail, Price, Amount, Amount * Price AS [Total] FROM Carts, Books WHERE Carts.ISBN = Books.ISBN AND Username = N'" + username + "'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Carts";
            return dt;
        }

        [WebMethod]
        public DataTable Search(string keyword)
        {
            // Add substring for string value
            string sql = "SELECT * FROM Orders WHERE OrderID LIKE '%" + keyword + "%' OR Username LIKE N'%" + keyword + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Orders";
            return dt;
        }

        [WebMethod]
        public bool AddCart(string isbn, string username, string amount)
        {
            string sql = "INSERT INTO Carts (ISBN, Username, Amount) VALUES ('" + isbn + "', N'" + username + "', " + amount + ")";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool EditCart(string isbn, string username, string amount)
        {
            string sql = "UPDATE Carts SET Amount = " + amount + " WHERE Username = N'" + username + "' AND ISBN = '" + isbn + "'";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool DeleteCart(string isbn, string username)
        {
            string sql = "DELETE FROM Carts WHERE ISBN = '" + isbn + "' AND Username = '" + username + "'";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// Orders
        /// </summary>
        [WebMethod]
        public DataTable GetOrder()
        {
            string sql = "SELECT * FROM Orders ORDER BY CreatedAt DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Orders";
            return dt;
        }

        [WebMethod]
        public DataTable GetOrderByUsername(string username)
        {
            string sql = "SELECT * FROM Orders WHERE Username = '" + username + "' ORDER BY CreatedAt DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Orders";
            return dt;
        }

        [WebMethod]
        public string CreateOrderID()
        {
            Random rand = new Random();
            string orderID = "";
            do
            {
                orderID = "BHT";
                for (int i = 0; i < 7; i++)
                    orderID += rand.Next(0, 10);
            } while (SQLQuery.ExecuteQuery("SELECT * FROM Orders WHERE OrderID = '" + orderID + "'").Rows.Count != 0);
            return orderID;
        }

        [WebMethod]
        public bool CreateOrder(string username)
        {
            string orderID = CreateOrderID();

            string sql = "INSERT INTO Orders VALUES ('" + orderID + "', " + TotalOrder(username) + ", " + TotalOrder(username) + ", 0, NULL, GETDATE(), '" + username + "')";
            if (SQLQuery.ExecuteNonQuery(sql) > 0)
            {
                DataTable dt = GetCartByUsername(username);
                foreach (DataRow row in dt.Rows)
                {
                    sql = "INSERT INTO OrderDetails(ISBN, OrderID, Amount) VALUES ('" + row["ISBN"] + "', '" + orderID + "', " + row["Amount"] + ")";
                    SQLQuery.ExecuteNonQuery(sql);
                }

                sql = "DELETE FROM Carts WHERE Username = '" + username + "'";
                return SQLQuery.ExecuteNonQuery(sql) > 0;
            }
            return false;
        }

        [WebMethod]
        public bool PaymentOrder(string username, string orderID)
        {
            string sql = @"IF ((SELECT Money FROM Users WHERE Username = '" + username + @"') >= (SELECT TotalMoney FROM Orders WHERE OrderID = '" + orderID + @"'))
                            BEGIN
                                DECLARE @totalMoney INT;
                                SELECT @totalMoney = TotalMoney FROM Orders WHERE OrderID = '" + orderID + @"';
                                UPDATE Users SET Money = Money - @totalMoney WHERE Username = '" + username + @"';
                                UPDATE Orders SET Status = 1, PaymentDate = GETDATE() WHERE OrderID = '" + orderID + @"';
                            END";
            return SQLQuery.ExecuteNonQuery(sql) > 1;
        }

        [WebMethod]
        public object TotalOrder(string username)
        {
            string sql = "SELECT ISNULL(SUM(Amount * Price), 0) FROM Carts, Books WHERE Carts.ISBN = Books.ISBN AND Username = N'" + username + "'";
            return SQLQuery.ExecuteScalar(sql);
        }

        [WebMethod]
        public object CountOrder(string username)
        {
            string sql = "SELECT COUNT(*) FROM Carts, Books WHERE Carts.ISBN = Books.ISBN AND Username = N'" + username + "'";
            return SQLQuery.ExecuteScalar(sql);
        }

        [WebMethod]
        public DataTable GetOrderBill(string orderID)
        {
            string sql = "SELECT * FROM Orders, Users WHERE Orders.Username = Users.Username AND OrderID = '" + orderID + "'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Orders";
            return dt;
        }

        [WebMethod]
        public DataTable GetOrderDetailBill(string orderID)
        {
            string sql = "SELECT Books.ISBN, BookTitle, Price, Amount, Price * Amount AS [TotalPrice] FROM OrderDetails, Books WHERE OrderDetails.ISBN = Books.ISBN AND OrderID = '" + orderID + "'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "OrderDetails";
            return dt;
        }

        /// <summary>
        /// OrderDetails
        /// </summary>
        [WebMethod]
        public DataTable GetOrderDetailsByOrderID(string orderID)
        {
            string sql = "SELECT * FROM OrderDetails WHERE OrderID = '" + orderID + "'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Orders";
            return dt;
        }
    }
}
