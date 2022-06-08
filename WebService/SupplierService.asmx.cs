using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class SupplierService : System.Web.Services.WebService
    {
        [WebMethod]
        public DataTable GetItemById(string id)
        {
            string sql = "SELECT * FROM Suppliers WHERE SupplierID = " + id;
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Suppliers";
            return dt;
        }

        [WebMethod]
        public DataTable GetTable()
        {
            string sql = "SELECT * FROM Suppliers ORDER BY SupplierID DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Suppliers";
            return dt;
        }

        [WebMethod]
        public DataTable GetTableWithPage(string startIndex)
        {
            string sql = "SELECT * FROM Suppliers ORDER BY SupplierID DESC OFFSET " + startIndex + " ROWS FETCH NEXT " + Content.RECORD_NUMBER_FOR_PAGE + " ROWS ONLY";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Suppliers";
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
                sub_sql = "SupplierID = '" + keyword + "' OR";
            }

            // Add substring for string value
            string sql = "SELECT * FROM Suppliers WHERE " + sub_sql + " SupplierName LIKE N'%" + keyword + "%' OR Phone LIKE N'%" + keyword + "%' OR Fax LIKE N'%" + keyword + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Suppliers";
            return dt;
        }

        [WebMethod]
        public bool Add(string supplierName, string phone, string address, string fax)
        {
            string sql = "INSERT INTO Suppliers(SupplierName, Phone, Address, Fax) VALUES (N'" + supplierName + "', N'" + phone + "', N'" + address + "', N'" + fax + "')";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Edit(string supplierID, string supplierName, string phone, string address, string fax)
        {
            string sql = "UPDATE Suppliers SET SupplierName = N'" + supplierName + "', Phone = N'" + phone + "', Address = N'" + address + "', Fax = N'" + fax + "' WHERE SupplierID = " + supplierID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool Delete(string supplierID)
        {
            string sql = "DELETE FROM Suppliers WHERE SupplierID = " + supplierID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }
    }
}
