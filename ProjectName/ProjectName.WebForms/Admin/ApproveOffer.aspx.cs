using System;
using System.Collections.Generic;

namespace Kupuvalnik.WebForms.Admin
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using BasicPage;
    using Models;

    public partial class ApproveOffer : BasePage
    {
        public void ApprovementOffers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.ApprovementOffers.PageIndex = e.NewPageIndex;
            Bind();
        }

        public void TaskGridView_RowUpdating(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int index = Convert.ToInt32(e.CommandArgument);  
                GridViewRow selectedRow = this.ApprovementOffers.Rows[index];
                var a = ((TextBox)selectedRow.Cells[0].Controls[0]).Text;
                var jewel = this.Data.Comodities.All().FirstOrDefault(c => c.Name == a && c.IsApproved==false);
             
                jewel.IsApproved = true;
                jewel.DateCreated = DateTime.Now;
                this.Data.SaveChanges();
                Bind();
            }
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);  
                GridViewRow selectedRow = this.ApprovementOffers.Rows[index];
                var a = ((HyperLink)selectedRow.Cells[0].Controls[0]).Text;
                var jewel = this.Data.Comodities.All().First(c => c.Name == a);
                this.Data.Comodities.Delete(jewel);
                this.Data.SaveChanges();
                Bind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            this.ApprovementOffers.DataSource = this.Data.Comodities.All().Where(c => c.IsApproved == false).ToList();    
            this.ApprovementOffers.DataBind();
        }
    }
}