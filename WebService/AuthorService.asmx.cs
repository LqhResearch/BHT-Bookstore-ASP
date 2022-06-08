using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class AuthorService : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable GetItemById(string id)
        {
            string sql = "SELECT * FROM Authors WHERE AuthorID = " + id;
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Authors";
            return dt;
        }

        [WebMethod]
        public DataTable GetTable()
        {
            string sql = "SELECT * FROM Authors ORDER BY AuthorID DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Authors";
            return dt;
        }

        [WebMethod]
        public DataTable GetTableWithPage(string startIndex)
        {
            string sql = "SELECT * FROM Authors ORDER BY AuthorID DESC OFFSET " + startIndex + " ROWS FETCH NEXT " + Content.RECORD_NUMBER_FOR_PAGE + " ROWS ONLY";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Authors";
            return dt;
        }

        [WebMethod]
        public DataTable Search(string keyword)
        {
            // Add substring for integer value
            int tmp = 0;
            string sub_sql = "";
            if (int.TryParse(keyword, out tmp))
            {
                sub_sql = "AuthorID = '" + keyword + "' OR";
            }

            // Add substring for string value
            string sql = "SELECT * FROM Authors WHERE " + sub_sql + " AuthorName LIKE N'%" + keyword + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Authors";
            return dt;
        }

        [WebMethod]
        public bool Add(string authorName, string contact)
        {
            string sql = "INSERT INTO Authors(AuthorName, Contact) VALUES (N'" + authorName + "', N'" + contact + "')";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Edit(string authorID, string authorName, string contact)
        {
            string sql = "UPDATE Authors SET AuthorName = N'" + authorName + "', Contact = N'" + contact + "' WHERE AuthorID = " + authorID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Delete(string authorID)
        {
            string sql = "DELETE FROM Authors WHERE AuthorID = " + authorID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }
    }
}
