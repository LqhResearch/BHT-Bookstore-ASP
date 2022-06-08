using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class StatisticalService : System.Web.Services.WebService
    {
        [WebMethod]
        public object CountTable(string table)
        {
            string sql = "SELECT COUNT(*) FROM " + table;
            return SQLQuery.ExecuteScalar(sql);
        }

        [WebMethod]
        public DataTable CategoryStatistical()
        {
            string sql = @"BEGIN 
	                        DECLARE @countAll INT
	                        DECLARE @countParent INT
	                        DECLARE @countChild INT
	                        DECLARE @countActive INT
	                        SELECT @countAll = COUNT(*) FROM Categories;
	                        SELECT @countParent = COUNT(*) FROM Categories WHERE ParentID = 0;
	                        SET @countChild = @countAll - @countParent;
	                        SELECT @countActive = COUNT(*) FROM Categories WHERE Active = 1;
	                        SELECT @countAll AS [CountAll], @countParent AS [CountParent], @countChild AS [CountChild], @countActive AS [CountActive]
                        END";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "CategoryStatistical";
            return dt;
        }

        [WebMethod]
        public DataTable AuthorStatistical()
        {
            string sql = @"BEGIN 
	                        DECLARE @countAll INT
	                        SELECT @countAll = COUNT(*) FROM Authors;
	                        SELECT @countAll AS [CountAll];
                        END";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "AuthorStatistical";
            return dt;
        }

        [WebMethod]
        public DataTable PublishStatistical()
        {
            string sql = @"BEGIN 
	                        DECLARE @countAll INT
	                        SELECT @countAll = COUNT(*) FROM Publishes;
	                        SELECT @countAll AS [CountAll];
                        END";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "PublishStatistical";
            return dt;
        }

        [WebMethod]
        public DataTable BookStatistical()
        {
            string sql = @"BEGIN 
	                        DECLARE @countAll INT
	                        SELECT @countAll = COUNT(*) FROM Books;
	                        SELECT @countAll AS [CountAll];
                        END";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "BookStatistical";
            return dt;
        }

        [WebMethod]
        public DataTable SupplierStatistical()
        {
            string sql = @"BEGIN 
	                        DECLARE @countAll INT
	                        SELECT @countAll = COUNT(*) FROM Suppliers;
	                        SELECT @countAll AS [CountAll];
                        END";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "SupplierStatistical";
            return dt;
        }

        [WebMethod]
        public DataTable OrderStatistical()
        {
            string sql = @"BEGIN 
	                        DECLARE @countAll INT
	                        DECLARE @countDelivered INT
	                        DECLARE @countNoDelivered INT
	                        DECLARE @monthProceeds INT
	                        SELECT @countAll = COUNT(*) FROM Orders;
	                        SELECT @countDelivered = COUNT(*) FROM Orders WHERE Status = 1;
	                        SELECT @countNoDelivered = COUNT(*) FROM Orders WHERE Status = 0;
	                        SELECT @monthProceeds = ISNULL(SUM(TotalRevenue), 0) FROM Orders WHERE MONTH(PaymentDate) = MONTH(GETDATE());
	                        SELECT @countAll AS [CountAll], @countDelivered AS [CountDelivered], @countNoDelivered AS [CountNoDelivered], @monthProceeds AS [MonthProceeds];
                        END";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "OrderStatistical";
            return dt;
        }

        [WebMethod]
        public DataTable UserStatistical()
        {
            string sql = @"BEGIN 
	                        DECLARE @countAll INT
	                        DECLARE @countAdmin INT
	                        DECLARE @countCustomer INT
	                        DECLARE @countActive INT
	                        SELECT @countAll = COUNT(*) FROM Users;
	                        SELECT @countAdmin = COUNT(*) FROM Users WHERE AccountTypeID = 1;
	                        SELECT @countCustomer = COUNT(*) FROM Users WHERE AccountTypeID = 3;
	                        SELECT @countActive = COUNT(*) FROM Users WHERE Status = 1;
	                        SELECT @countAll AS [CountAll], @countAdmin AS [CountAdmin], @countCustomer AS [CountCustomer], @countActive AS [CountActive];
                        END";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "UserStatistical";
            return dt;
        }

        [WebMethod]
        public DataTable SliderStatistical()
        {
            string sql = @"BEGIN 
	                        DECLARE @countAll INT
	                        SELECT @countAll = COUNT(*) FROM Sliders;
	                        SELECT @countAll AS [CountAll];
                        END";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "SupplierStatistical";
            return dt;
        }
    }
}
