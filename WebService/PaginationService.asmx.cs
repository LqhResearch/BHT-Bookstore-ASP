using System;
using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class PaginationService : System.Web.Services.WebService
    {
        #region Properties
        string TableName { get; set; }
        int TotalItems { get; set; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        int ItemsCurrentPage { get; set; }
        int StartIndex { get; set; }
        #endregion

        [WebMethod]
        public DataTable Process(string tableName, int currentPage, int pageSize)
        {
            TableName = tableName;
            TotalItems = TableCount(TableName);
            CurrentPage = currentPage;
            PageSize = Content.RECORD_NUMBER_FOR_PAGE;
            ItemsCurrentPage = TotalItemsCurrentPage();
            StartIndex = (CurrentPage - 1) * PageSize;

            DataTable dt = new DataTable();
            dt.TableName = "Pagination";
            dt.Columns.Add("totalitems");
            dt.Columns.Add("currentpage");
            dt.Columns.Add("pagesize");
            dt.Columns.Add("totalpages");
            dt.Columns.Add("startpage");
            dt.Columns.Add("endpage");
            dt.Columns.Add("startindex");
            dt.Columns.Add("endindex");

            DataRow row = dt.NewRow();
            row["TotalItems"] = TotalItems;
            row["CurrentPage"] = CurrentPage;
            row["PageSize"] = PageSize;
            row["TotalPages"] = TotalPages();
            row["StartPage"] = StartIndex + 1;
            row["EndPage"] = StartIndex + ItemsCurrentPage;
            row["StartIndex"] = StartIndex;
            row["EndIndex"] = StartIndex + ItemsCurrentPage;
            dt.Rows.Add(row);
            return dt;
        }

        public int TableCount(string tableName) => (int)SQLQuery.ExecuteScalar("SELECT count(*) FROM " + tableName);

        public int TotalPages() => (int)Math.Ceiling(1.0 * TotalItems / PageSize);

        public int TotalItemsCurrentPage()
        {
            int value = TotalItems - ((CurrentPage - 1) * PageSize);
            return value >= PageSize ? PageSize : value;
        }
    }
}
