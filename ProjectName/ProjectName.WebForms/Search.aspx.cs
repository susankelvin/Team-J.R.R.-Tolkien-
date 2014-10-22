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
    using System.Text.RegularExpressions;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var query = this.Data.Comodities.All();
            string name = this.tbName.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name == name);
            }

            string description = this.tbDescription.Text;
            //if (!string.IsNullOrWhiteSpace(description))
            //{
            //    string descriptionLower = description.ToLower();
            //    query = query.Where(c =>
            //    {
            //        string itemDescriptionLower = c.Description.ToLower();
            //        return itemDescriptionLower.Contains(descriptionLower);
            //    });
            //}

            string username = this.tbAuthor.Text;
            if (!string.IsNullOrWhiteSpace(username))
            {
                query = query.Include("Author").Where(c => c.Author.UserName == username);
            }

            this.SearchGrid.DataSource = query.ToList();
            this.DataBind();
        }
    }
}