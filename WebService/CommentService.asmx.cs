using System.Data;
using System.Web.Services;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CommentService : System.Web.Services.WebService
    {
        /// <summary>
        /// Comments
        /// </summary>
        [WebMethod]
        public DataTable GetCommentAndRatingByISBN(string isbn)
        {
            string sql = "SELECT * FROM Comments, Rating, Users WHERE Comments.CommentID = Rating.RatingID AND Comments.Username = Users.Username AND Comments.ISBN = '" + isbn + "' ORDER BY Comments.CreatedAt DESC";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            dt.TableName = "Comments";
            return dt;
        }

        [WebMethod]
        public bool AddComment(string isbn, string username, string desc, string active = "0")
        {
            string sql = "INSERT INTO Comments (ISBN, Username, Description, Active) VALUES ('" + isbn + "', N'" + username + "', N'" + desc + "', " + active + ")";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool EditComment(string commentID, string desc, string active = "0")
        {
            string sql = "UPDATE Comments SET Description = N'" + desc + "', Active = " + active + " WHERE CommentID = " + commentID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool DeleteComment(string commentID)
        {
            string sql = "DELETE FROM Comments WHERE CommentID = " + commentID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// Rating
        /// </summary>
        [WebMethod]
        public bool AddRating(string isbn, string username, string point)
        {
            string sql = "INSERT INTO Rating (ISBN, Username, Point) VALUES ('" + isbn + "', N'" + username + "', " + point + ")";
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool EditRating(string ratingID, string point)
        {
            string sql = "UPDATE Rating SET Point = " + point + " WHERE Rating = " + ratingID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }

        [WebMethod]
        public bool DeleteRating(string ratingID)
        {
            string sql = "DELETE FROM Rating WHERE Rating = " + ratingID;
            return SQLQuery.ExecuteNonQuery(sql) > 0;
        }
    }
}
