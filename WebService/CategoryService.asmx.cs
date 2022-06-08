using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CategoryService : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable GetItemById(string id)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryID = " + id;
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Categories";
            return dt;
        }

        [WebMethod]
        public DataTable GetTable()
        {
            string sql = "SELECT a.*, b.CategoryName AS ParentName FROM Categories a LEFT JOIN Categories b ON a.ParentID = b.CategoryID ORDER BY a.CategoryID DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Categories";
            return dt;
        }

        [WebMethod]
        public DataTable GetTableWithPage(string startIndex)
        {
            string sql = "SELECT a.*, b.CategoryName AS ParentName FROM Categories a LEFT JOIN Categories b ON a.ParentID = b.CategoryID ORDER BY a.CategoryID DESC OFFSET " + startIndex + " ROWS FETCH NEXT " + Content.RECORD_NUMBER_FOR_PAGE + " ROWS ONLY";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Categories";
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
                sub_sql = "a.CategoryID = '" + keyword + "' OR";
            }

            // Add substring for string value
            string sql = "SELECT a.*, b.CategoryName AS ParentName FROM Categories a LEFT JOIN Categories b ON a.ParentID = b.CategoryID WHERE " + sub_sql + " a.CategoryName LIKE N'%" + keyword + "%' ORDER BY a.CategoryID DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Categories";
            return dt;
        }

        [WebMethod]
        public bool Add(string categoryName, string parentID)
        {
            string sql = "INSERT INTO Categories(CategoryName, ParentID) VALUES (N'" + categoryName + "', " + parentID + ")";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Edit(string categoryID, string categoryName, string parentID, string active)
        {
            string sql = "UPDATE Categories SET CategoryName = N'" + categoryName + "', ParentID = '" + parentID + "', Active = " + active + " WHERE CategoryID = " + categoryID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Delete(string categoryID)
        {
            string sql = "DELETE FROM Categories WHERE CategoryID = " + categoryID + " OR ParentID = " + categoryID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public DataTable GetParentCategories()
        {
            string sql = "SELECT * FROM Categories WHERE ParentID = 0 AND Active = 1";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Categories";
            return dt;
        }
    }
}
