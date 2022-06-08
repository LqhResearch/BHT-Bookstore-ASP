using System;
using System.Data;

namespace WebForm
{
    public partial class Sign : System.Web.UI.Page
    {
        UserService.UserServiceSoapClient user = new UserService.UserServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    string type = Request.QueryString["type"];

                    //Google sign in
                    if (type == "google")
                    {
                        string client_id = "92829760731-q200nvrt60pscl0ub3tdhu6mojahjue0.apps.googleusercontent.com";
                        string redirection_url = "https://localhost:44366/Google.aspx";
                        string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=profile email&include_granted_scopes=true&redirect_uri=" + redirection_url + "&response_type=code&client_id=" + client_id;
                        Response.Redirect(url);
                    }
                }
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtPassword1_SignUp.Text == txtPassword2_SignUp.Text)
            {
                if (user.SignUp(txtUsername_SignUp.Text, txtPassword1_SignUp.Text, txtFullname_SignUp.Text, txtEmail_SignUp.Text))
                {
                    SetSession(txtUserName_SignIn.Text);
                    lblMessage_SignUp.Text = "Đăng ký thành công";
                }
                else lblMessage_SignUp.Text = "Đăng ký thất bại";
            }
            else lblMessage_SignUp.Text = "Mật khẩu không khớp";
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (user.Login(txtUserName_SignIn.Text, txtPassword_SignIn.Text))
            {
                SetSession(txtUserName_SignIn.Text);
                Response.Redirect("/");
            }
            else
                lblMessage_SignIn.Text = "Tên đăng nhập hoặc mật khẩu không hợp lệ";
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