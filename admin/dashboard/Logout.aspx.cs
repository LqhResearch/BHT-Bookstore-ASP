using System;

namespace BHT_Bookstore_ASP_NET.admin.dashboard
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.Clear();
                Response.Redirect("/admin/dashboard/Login.aspx");
            }
        }
    }
}