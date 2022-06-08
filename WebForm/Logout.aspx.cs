﻿using System;

namespace WebForm
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["login"] = false;
                Response.Redirect("/Default.aspx");
            }
        }
    }
}