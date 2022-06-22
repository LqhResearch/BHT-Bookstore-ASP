using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class SliderService : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable GetItemById(string id)
        {
            string sql = "SELECT * FROM Sliders WHERE SliderID = " + id;
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Sliders";
            return dt;
        }

        [WebMethod]
        public DataTable GetTable()
        {
            string sql = "SELECT * FROM Sliders ORDER BY SliderID DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Sliders";
            return dt;
        }

        [WebMethod]
        public DataTable GetTableWithPage(string startIndex)
        {
            string sql = "SELECT * FROM Sliders ORDER BY SliderID DESC OFFSET " + startIndex + " ROWS FETCH NEXT " + Content.RECORD_NUMBER_FOR_PAGE + " ROWS ONLY";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Sliders";
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
                sub_sql = "SliderID = " + tmp + " OR";
            }

            // Add substring for string value
            string sql = "SELECT * FROM Sliders WHERE " + sub_sql + " SliderName LIKE N'%" + keyword + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Sliders";
            return dt;
        }

        [WebMethod]
        public bool Add(string sliderName, string description, string thumbnail, string status)
        {
            string sql = "INSERT INTO Sliders(SliderName, Description, Thumbnail, Status) VALUES (N'" + sliderName + "', N'" + description + "', N'" + thumbnail + "', " + status + ")";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Edit(string sliderID, string sliderName, string description, string thumbnail, string status)
        {
            string sub_sql = "";
            if (thumbnail != "")
                sub_sql = ", Thumbnail = N'" + thumbnail + "'";

            string sql = "UPDATE Sliders SET SliderName = N'" + sliderName + "', Description = N'" + description + "' " + sub_sql + ", Status = " + status + " WHERE SliderID = " + sliderID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Delete(string sliderID)
        {
            string sql = "DELETE FROM Sliders WHERE SliderID = " + sliderID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }
    }
}
