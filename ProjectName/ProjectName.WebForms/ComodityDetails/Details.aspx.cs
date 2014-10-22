namespace Kupuvalnik.WebForms.ComodityDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Kupuvalnik.WebForms.BasicPage;
    using Kupuvalnik.WebForms.Models;
    
    public partial class Details : BasePage
    {
        public Comodity Comodity { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int currentComodityId = 0;
            try
            {
                currentComodityId = int.Parse(Request.CurrentExecutionFilePath.TrimStart('/'));
            }
            catch (Exception)
            {
                Response.Redirect("/");
            }

            this.Comodity = this.Data.Comodities.All().FirstOrDefault(c => c.ComodityId == currentComodityId);
            if (this.Comodity == null)
            {
                Response.Redirect("/");
            }
        }
    }
}