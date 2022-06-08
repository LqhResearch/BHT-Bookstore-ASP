using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class GoogleService : System.Web.Services.WebService
    {
        private string client_id = "92829760731-q200nvrt60pscl0ub3tdhu6mojahjue0.apps.googleusercontent.com";
        private string client_secret = "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";
        private string redirection_url = "https://localhost:44366/Google.aspx";
        private string url = "https://accounts.google.com/o/oauth2/token";

        public UserClass GetUserProfile(string access_token)
        {
            string url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + access_token;

            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;

            Stream dataStream = request.GetResponse().GetResponseStream();
            string responseFromServer = new StreamReader(dataStream).ReadToEnd();

            return new JavaScriptSerializer().Deserialize<UserClass>(responseFromServer);
        }

        [WebMethod]
        public UserClass GetToken(string code)
        {
            string post = "grant_type=authorization_code&code=" + code + "&client_id=" + client_id + "&client_secret=" + client_secret + "&redirect_uri=" + redirection_url + "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            byte[] bytes = new UTF8Encoding().GetBytes(post);

            Stream outputstream = null;
            try
            {
                request.ContentLength = bytes.Length;
                outputstream = request.GetRequestStream();
                outputstream.Write(bytes, 0, bytes.Length);
            }
            catch { }
            var streamReader = new StreamReader(request.GetResponse().GetResponseStream());
            string responseFromServer = streamReader.ReadToEnd();

            TokenClass token = new JavaScriptSerializer().Deserialize<TokenClass>(responseFromServer);
            return GetUserProfile(token.access_token);
        }

        [WebMethod]
        public bool GoogleSignUp(UserClass userinfo)
        {
            string sql = "SELECT * FROM Users WHERE Email = '" + userinfo.email + "'";
            if (SQLQuery.ExecuteQuery(sql).Rows.Count == 0)
            {
                sql = "INSERT INTO Users (Username, Fullname, Email, Avatar, AccountTypeID) VALUES (N'" + userinfo.email + "', N'" + userinfo.name + "', N'" + userinfo.email + "', '" + userinfo.picture + "', 3)";
                return SQLQuery.ExecuteNonQuery(sql) > 0;
            }
            return false;
        }
    }

    public class UserClass
    {
        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string link { get; set; }
        public string picture { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
        public string email { get; set; }
    }

    public class TokenClass
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}
