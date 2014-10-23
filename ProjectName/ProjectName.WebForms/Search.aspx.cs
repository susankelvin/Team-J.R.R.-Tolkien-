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
    using System.Data;

    public partial class Search : BasePage
    {
        public void SearchGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            ////Sort the data.
            //(this.Data.Comodities as DataTable).DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            //SearchGrid.DataSource = Session["TaskTable"];
            //SearchGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.SearchGrid.DataSource = this.Data.Comodities.All().Include("Author").ToList();
                this.SearchGrid.DataBind();
                
                var categories = this.Data.Categories.All().ToList();
                categories.Insert(0, new Category() { CategoryId = 0, Name = "" });

                this.DropDownListxCategories.DataSource = categories;
                
                this.DropDownListxCategories.DataBind();
            }
        }

        public void SearchGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.SearchGrid.PageIndex = e.NewPageIndex;
            var comodities = this.Data.Comodities.All().Include("Author");

            if (!string.IsNullOrWhiteSpace(this.DropDownListxCategories.SelectedItem.Text))
            {
                comodities = comodities.Where(c => c.Category.Name == this.DropDownListxCategories.SelectedItem.Text);
            }

            this.SearchGrid.DataSource = comodities.ToList();
            this.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var query = this.Data.Comodities.All();
            string name = this.tbName.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            string description = this.tbDescription.Text;
            if (!string.IsNullOrWhiteSpace(description))
            {
                string descriptionLower = description.ToLower();
                query = query.Where(c => c.Description.Contains(descriptionLower));
            }
           
            string username = this.tbAuthor.Text;
            if (!string.IsNullOrWhiteSpace(username))
            {
                query = query.Include("Author").Where(c => c.Author.UserName.Contains(username));
            }

            string category = this.DropDownListxCategories.SelectedItem.Text;
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Include("Category").Where(c => c.Category.Name == category);
            }

            this.SearchGrid.DataSource = query.ToList();
            this.DataBind();
        }

        private string GetSortDirection(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }
    }
}