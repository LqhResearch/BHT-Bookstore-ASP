using System;

namespace BHT_Bookstore_ASP_NET
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Users VALUES (N'" + txtUsername.Text + "', '" + Encryption.EncodeSHA1(txtPassword.Text) + "', N'" + txtFullname.Text + "', '" + txtPhone.Text + "', '" + txtEmail.Text + "', '', 1, GETDATE(), 3)";
            SQLQuery.ExecuteNonQuery(sql);
            Response.Redirect("/Default.aspx");
        }
    }
}