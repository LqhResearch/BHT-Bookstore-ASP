using System;
using System.Data;

namespace WebForm
{
    public partial class Google : System.Web.UI.Page
    {
        GoogleService.GoogleServiceSoapClient google = new GoogleService.GoogleServiceSoapClient();
        UserService.UserServiceSoapClient user = new UserService.UserServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["code"] != null)
                {
                    dynamic userinfo = google.GetToken(Request.QueryString["code"]);
                    google.GoogleSignUp(userinfo);
                    SetSession(userinfo.email);
                }
                if (Request.QueryString["username"] != null)
                {
                    string username = Request.QueryString["username"];
                    SetSession(username);
                }
            }
            Response.Redirect("/");
        }

        private void SetSession(string username)
        {
            DataTable dt = user.GetItemById(username);
            if (dt.Rows.Count > 0)
            {
                Session["Login"] = true;
                Session["Username"] = dt.Rows[0]["Username"];
                Session["DisplayName"] = dt.Rows[0]["Fullname"];
                Session["Avatar"] = dt.Rows[0]["Avatar"];
                Session["Role"] = dt.Rows[0]["AccountTypeID"];
            }
        }
    }
}