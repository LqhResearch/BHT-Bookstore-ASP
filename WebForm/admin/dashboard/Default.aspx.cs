using System;

namespace WebForm.admin.dashboard
{
    public partial class Default : System.Web.UI.Page
    {
        StatisticalService.StatisticalServiceSoapClient statistical = new StatisticalService.StatisticalServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCountCategories.Text = statistical.CountTable("Categories").ToString();
                lblCountAuthors.Text = statistical.CountTable("Authors").ToString();
                lblCountPublishes.Text = statistical.CountTable("Publishes").ToString();
                lblCountSuppliers.Text = statistical.CountTable("Suppliers").ToString();
                lblCountBooks.Text = statistical.CountTable("Books").ToString();
                lblCountOrders.Text = statistical.CountTable("Orders").ToString();
                lblCountUsers.Text = statistical.CountTable("Users").ToString();
                lblCountSliders.Text = statistical.CountTable("Sliders").ToString();
            }
        }
    }
}