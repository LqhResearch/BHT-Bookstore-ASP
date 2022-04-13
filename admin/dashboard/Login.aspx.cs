using System;
using System.Data;

namespace BHT_Bookstore_ASP_NET.admin.dashboard
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Convert.ToBoolean(Session["Admin_Login"]))
                    Response.Redirect("/admin/dashboard/Default.aspx");
            }
        }

        [Obsolete]
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT UserName, Fullname, Avatar FROM Users 
                        WHERE UserName = '" + txtUsername.Text + @"' AND PassWord = '" + Encryption.EncodeSHA1(txtPassword.Text) + @"' 
                        AND Status = 1";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            if (dt.Rows.Count == 1)
            {
                Session.Add("Admin_Login", true);
                Session.Add("UserName", dt.Rows[0]["UserName"]);
                Session.Add("Fullname", dt.Rows[0]["Fullname"]);
                Session.Add("Avatar", dt.Rows[0]["Avatar"]);

                Response.Redirect("/admin/dashboard/Default.aspx");
            }
            else lblMessage.Text = "<div class='alert alert-warning'><strong>Cảnh báo!</strong> Tên đăng nhập hoặc mật khẩu không hợp lệ</div>";
        }
    }
}