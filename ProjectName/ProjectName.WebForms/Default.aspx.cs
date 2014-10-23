namespace Kupuvalnik.WebForms
{
    using System;
    using System.Linq;
    using Kupuvalnik.WebForms.BasicPage;
    
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LatestOffers.DataSource = this.Data.Comodities.All().Where(c => c.IsApproved == true).OrderByDescending(c => c.DateCreated).Take(10).ToList();
            this.LatestOffers.DataBind();
        }
    }
}