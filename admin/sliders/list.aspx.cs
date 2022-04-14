using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BHT_Bookstore_ASP_NET.admin.sliders
{
    public partial class list : System.Web.UI.Page
    {
        public static Dictionary<string, int> pager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set default properties
                int page = Request.QueryString["page"] != null ? Convert.ToInt32(Request.QueryString["page"]) : 1;
                pager = Pagination.Process("Sliders", page, Content.RECORD_NUMBER_FOR_PAGE);

                ShowEdit();
                DeleteData();
                GetTable();
            }
        }

        #region This function
        private void ShowEdit()
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();

                DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Sliders WHERE SliderID = " + id);
                txtID_Edit.Text = dt.Rows[0]["SliderID"].ToString();
                txtName_Edit.Text = dt.Rows[0]["Name"].ToString();
                txtSlogan_Edit.Text = dt.Rows[0]["Description"].ToString();
                ddlStatus_Edit.SelectedValue = Convert.ToInt32(dt.Rows[0]["Status"]).ToString();
            }
        }

        private void DeleteData()
        {
            if (Request.QueryString["del-id"] != null)
            {
                string id = Request.QueryString["del-id"].ToString();

                string sql = @"DELETE FROM Sliders WHERE SliderID = " + id;
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    lblMessage.Text = Content.SuccessDeleteMessage;
            }
        }

        private void GetTable()
        {
            DataTable dt = SQLQuery.ExecuteQuery("SELECT * FROM Sliders ORDER BY SliderID DESC OFFSET " + pager["StartIndex"] + " ROWS FETCH NEXT " + pager["PageSize"] + " ROWS ONLY");
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
        }
        #endregion

        private bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        protected void btnSubmit_Add_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && fThumbnail_Add.HasFile && CheckFileType(fThumbnail_Add.FileName))
            {
                string fileName = "/uploads/" + fThumbnail_Add.FileName;
                string filePath = MapPath(fileName);
                fThumbnail_Add.SaveAs(filePath);

                string sql = @"INSERT INTO Sliders (Name, Description, Thumbnail, Status) VALUES (N'" + txtName_Add.Text + "', N'" + txtSlogan_Add.Text + "', N'" + fileName + "', N'" + ddlStatus_Add.SelectedValue + "')";
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    Response.Redirect("list.aspx");
            }
        }

        protected void btnSubmit_Edit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && fThumbnail_Edit.HasFile && CheckFileType(fThumbnail_Edit.FileName))
            {
                string fileName = "/uploads/" + fThumbnail_Edit.FileName;
                string filePath = MapPath(fileName);
                fThumbnail_Edit.SaveAs(filePath);

                string sql = @"UPDATE Sliders SET Name = N'" + txtName_Edit.Text + "', Description = N'" + txtSlogan_Edit.Text + "', Thumbnail = N'" + fileName + "', Status = " + ddlStatus_Edit.SelectedValue + " WHERE SliderID = " + txtID_Edit.Text;
                if (SQLQuery.ExecuteNonQuery(sql) > 0)
                    Response.Redirect("list.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Sliders WHERE Name LIKE N'%" + txtSearch.Text + "%'";
            DataTable dt = SQLQuery.ExecuteQuery(sql);
            rptList.DataSource = dt;
            rptList.DataBind();
            if (dt.Rows.Count == 0)
                lblList.Text = Content.RepeaterNoData;
            lblPaginationDisable.CssClass = "d-none";
        }
    }
}