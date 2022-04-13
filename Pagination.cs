using System;
using System.Collections.Generic;

namespace BHT_Bookstore_ASP_NET
{
    public class Pagination
    {
        #region Properties
        static string TableName { get; set; }
        static int TotalItems { get; set; }
        static int CurrentPage { get; set; }
        static int PageSize { get; set; }
        static int ItemsCurrentPage { get; set; }
        static int StartIndex { get; set; }
        #endregion

        public static Dictionary<string, int> Process(string tableName, int currentPage, int pageSize)
        {
            TableName = tableName;
            TotalItems = TableCount(TableName);
            CurrentPage = currentPage;
            PageSize = Content.RECORD_NUMBER_FOR_PAGE;
            ItemsCurrentPage = TotalItemsCurrentPage();
            StartIndex = (CurrentPage - 1) * PageSize;

            Dictionary<string, int> pager = new Dictionary<string, int>();
            pager.Add("TotalItems", TotalItems);
            pager.Add("CurrentPage", CurrentPage);
            pager.Add("PageSize", PageSize);
            pager.Add("TotalPages", TotalPages());
            pager.Add("StartPage", StartIndex + 1);
            pager.Add("EndPage", StartIndex + ItemsCurrentPage);
            pager.Add("StartIndex", StartIndex);
            pager.Add("EndIndex", StartIndex + ItemsCurrentPage);
            return pager;
        }
        public static int TableCount(string tableName) => (int)SQLQuery.ExecuteScalar("SELECT count(*) FROM " + tableName);

        public static int TotalPages() => (int)Math.Ceiling(1.0 * TotalItems / PageSize);

        public static int TotalItemsCurrentPage()
        {
            int value = TotalItems - ((CurrentPage - 1) * PageSize);
            return value >= PageSize ? PageSize : value;
        }
    }
}