using System;
using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class UserService : System.Web.Services.WebService
    {
        [WebMethod]
        [Obsolete]
        public bool Login(string username, string password)
        {
            string sql = "SELECT * FROM Users WHERE (Username = N'" + username + "' OR Email = '" + username + "') AND Password = '" + Encryption.EncodeSHA1(password) + "'";
            return SQLQuery.ExecuteQuery(sql).Rows.Count > 0;
        }

        [WebMethod]
        [Obsolete]
        public bool SignUp(string username, string password, string fullname, string email)
        {
            string sql = "INSERT INTO Users (Username, Password, Fullname, Email, AccountTypeID) VALUES (N'" + username + "', '" + Encryption.EncodeSHA1(password) + "', '" + fullname + "', '" + email + "', 3)";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Edit(string username, string status, string accountTypeID)
        {
            string sql = "UPDATE Users SET Status = " + status + ", AccountTypeID = " + accountTypeID + " WHERE Username = N'" + username + "'";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Delete(string username)
        {
            string sql = "DELETE FROM Users WHERE Username = N'" + username + "'";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public DataTable GetItemById(string id)
        {
            string sql = "SELECT Username, Fullname, Phone, Email, Avatar, Status, Users.AccountTypeID, AccountTypeName FROM Users, AccountTypes WHERE Users.AccountTypeID = AccountTypes.AccountTypeID AND Username = N'" + id + "'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Users";
            return dt;
        }

        [WebMethod]
        public DataTable GetTable()
        {
            string sql = "SELECT Username, Fullname, Phone, Email, Avatar, Status, Users.AccountTypeID, AccountTypeName FROM Users, AccountTypes WHERE Users.AccountTypeID = AccountTypes.AccountTypeID ORDER BY AccountTypes.AccountTypeID";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Users";
            return dt;
        }

        [WebMethod]
        public DataTable GetTableWithPage(string startIndex)
        {
            string sql = "SELECT Username, Fullname, Phone, Email, Avatar, Status, Users.AccountTypeID, AccountTypeName FROM Users, AccountTypes WHERE Users.AccountTypeID = AccountTypes.AccountTypeID ORDER BY AccountTypes.AccountTypeID OFFSET " + startIndex + " ROWS FETCH NEXT " + Content.RECORD_NUMBER_FOR_PAGE + " ROWS ONLY";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Users";
            return dt;
        }

        [WebMethod]
        public DataTable Search(string keyword)
        {
            // Add substring for string value
            string sql = "SELECT Username, Fullname, Phone, Email, Avatar, Status, Users.AccountTypeID, AccountTypeName FROM Users, AccountTypes WHERE Users.AccountTypeID = AccountTypes.AccountTypeID AND (Username LIKE N'%" + keyword + "%' OR Fullname LIKE N'%" + keyword + "%' OR Email LIKE N'%" + keyword + "%')";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Users";
            return dt;
        }

        [WebMethod]
        public DataTable GetAccountTypeTable()
        {
            string sql = "SELECT * FROM AccountTypes";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "AccountTypes";
            return dt;
        }

        [WebMethod]
        public object GetMoney(string username)
        {
            string sql = "SELECT Money FROM Users WHERE Username = '" + username + "'";
            return SQLQuery.ExecuteScalar(sql);
        }
    }
}
