using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class PublishService : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable GetItemById(string id)
        {
            string sql = "SELECT * FROM Publishes WHERE PublishID = " + id;
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Publishes";
            return dt;
        }

        [WebMethod]
        public DataTable GetTable()
        {
            string sql = "SELECT * FROM Publishes ORDER BY PublishID DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Publishes";
            return dt;
        }

        [WebMethod]
        public DataTable GetTableWithPage(string startIndex)
        {
            string sql = "SELECT * FROM Publishes ORDER BY PublishID DESC OFFSET " + startIndex + " ROWS FETCH NEXT " + Content.RECORD_NUMBER_FOR_PAGE + " ROWS ONLY";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Publishes";
            return dt;
        }

        [WebMethod]
        public DataTable Search(string keyword)
        {
            // Add substring for integer value
            int tmp;
            string sub_sql = "";
            if (int.TryParse(keyword, out tmp))
            {
                sub_sql = "PublishID = " + tmp + " OR";
            }

            // Add substring for string value
            string sql = "SELECT * FROM Publishes WHERE " + sub_sql + " PublishName LIKE N'%" + keyword + "%' OR Phone LIKE N'%" + keyword + "%' OR Fax LIKE N'%" + keyword + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Publishes";
            return dt;
        }

        [WebMethod]
        public bool Add(string publishName, string phone, string address, string fax)
        {
            string sql = "INSERT INTO Publishes(PublishName, Phone, Address, Fax) VALUES (N'" + publishName + "', N'" + phone + "', N'" + address + "', N'" + fax + "')";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Edit(string publishID, string publishName, string phone, string address, string fax)
        {
            string sql = "UPDATE Publishes SET PublishName = N'" + publishName + "', Phone = N'" + phone + "', Address = N'" + address + "', Fax = N'" + fax + "' WHERE PublishID = " + publishID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Delete(string publishID)
        {
            string sql = "DELETE FROM Publishes WHERE PublishID = " + publishID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }
    }
}
