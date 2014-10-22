namespace Kupuvalnik.WebForms
{
    using Kupuvalnik.WebForms.BasicPage;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Kupuvalnik.WebForms.Models;

    public partial class Search : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.SearchGrid.DataSource = this.Data.Comodities.All().Include("Author").ToList();
                this.DataBind();
            }
        }


    }
}