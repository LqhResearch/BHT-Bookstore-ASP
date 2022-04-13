using System;

namespace BHT_Bookstore_ASP_NET.admin
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (!Convert.ToBoolean(Session["Admin_Login"]))
            //        Response.Redirect("/admin/dashboard/Login.aspx");
            //}
        }
    }
}