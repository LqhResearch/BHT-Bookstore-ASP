using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class BookService : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable GetItemById(string id)
        {
            string sql = "SELECT * FROM Books, Languages, Categories, Publishes WHERE Books.LanguageID = Languages.LanguageID AND Books.CategoryID = Categories.CategoryID AND Books.PublishID = Publishes.PublishID AND ISBN = " + id;
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Books";
            return dt;
        }

        [WebMethod]
        public DataTable GetTable()
        {
            string sql = "SELECT * FROM Books, Languages, Categories, Publishes WHERE Books.LanguageID = Languages.LanguageID AND Books.CategoryID = Categories.CategoryID AND Books.PublishID = Publishes.PublishID";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Books";
            return dt;
        }

        [WebMethod]
        public DataTable GetTableWithPage(string startIndex)
        {
            string sql = "SELECT * FROM Books, Languages, Categories, Publishes WHERE Books.LanguageID = Languages.LanguageID AND Books.CategoryID = Categories.CategoryID AND Books.PublishID = Publishes.PublishID ORDER BY BookTitle DESC OFFSET " + startIndex + " ROWS FETCH NEXT " + Content.RECORD_NUMBER_FOR_PAGE + " ROWS ONLY";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Books";
            return dt;
        }

        [WebMethod]
        public DataTable Search(string keyword)
        {
            string sql = "SELECT * FROM Books, Languages, Categories, Publishes WHERE Books.LanguageID = Languages.LanguageID AND Books.CategoryID = Categories.CategoryID AND Books.PublishID = Publishes.PublishID AND (Books.ISBN LIKE N'%" + keyword + "%' OR Books.BookTitle LIKE N'%" + keyword + "%')";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Books";
            return dt;
        }

        [WebMethod]
        public bool Add(string isbn, string bookTitle, string description, string publishYear, string weight, string size, string pageNumber, string thumbnail, string languageID, string price, string quantitySold, string inventoryNumber, string categoryID, string publishID)
        {
            string sql = "IF NOT EXISTS (SELECT * FROM Books WHERE ISBN = '" + isbn + "') BEGIN INSERT INTO Books VALUES ('" + isbn + "', N'" + bookTitle + "', N'" + description + "', " + publishYear + ", " + weight + ", N'" + size + "', " + pageNumber + ", N'" + thumbnail + "', N'" + languageID + "', " + price + ", " + quantitySold + ", " + inventoryNumber + ", " + categoryID + ", " + publishID + ") END";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Edit(string isbn, string bookTitle, string description, string publishYear, string weight, string size, string pageNumber, string thumbnail, string languageID, string price, string quantitySold, string inventoryNumber, string categoryID, string publishID)
        {
            string sub_sql = "";
            if (thumbnail != "")
                sub_sql = ", Thumbnail = N'" + thumbnail + "'";

            string sql = "UPDATE Books SET BookTitle = N'" + bookTitle + "', Description = N'" + description + "', PublishYear = " + publishYear + ", Weight = " + weight + ", Size = '" + size + "', PageNumber = " + pageNumber + " " + sub_sql + ", LanguageID = N'" + languageID + "', Price = " + price + ", QuantitySold = " + quantitySold + ", InventoryNumber = " + inventoryNumber + ", CategoryID = " + categoryID + ", PublishID = " + publishID + " WHERE ISBN = '" + isbn + "'";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Delete(string isbn)
        {
            string sql = "DELETE FROM Books WHERE ISBN = '" + isbn + "'";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public DataTable GetLanguageTable()
        {
            string sql = "SELECT * FROM Languages WHERE LanguageID = 'vi' OR LanguageID = 'en' ORDER BY LanguageID DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Languages";
            return dt;
        }

        [WebMethod]
        public DataTable GetLastedBooks()
        {
            string sql = "SELECT TOP 5 * FROM Books ORDER BY PublishYear DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Books";
            return dt;
        }

        [WebMethod]
        public DataTable GetTop3Books()
        {
            string sql = "SELECT TOP 3 * FROM Books ORDER BY PublishYear DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Books";
            return dt;
        }

        [WebMethod]
        public DataTable GetTableByCategory(string categoryID)
        {
            string sql = "SELECT * FROM Books WHERE CategoryID = " + categoryID;
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Books";
            return dt;
        }
    }
}
