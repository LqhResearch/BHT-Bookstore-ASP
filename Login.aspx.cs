using System;
using System.Data;

namespace BHT_Bookstore_ASP_NET
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Users WHERE UserName = N'" + txtUsername.Text + "' AND PassWord = '" + Encryption.EncodeSHA1(txtPassword.Text) + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Session["user_login"] = true;
                Session["user_displayName"] = row["Fullname"].ToString() == "" ? row["Username"] : row["Fullname"];
                Session["user_type"] = row["AccountTypeID"];
                Session["username"] = row["Username"];
                Session["avatar"] = row["Avatar"];
                Response.Redirect("/Default.aspx");
            }
        }
    }
}