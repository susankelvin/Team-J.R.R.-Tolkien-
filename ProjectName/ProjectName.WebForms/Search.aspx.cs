namespace Kupuvalnik.WebForms
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Kupuvalnik.WebForms.BasicPage;
    using Kupuvalnik.WebForms.Models;

    public partial class Search : BasePage
    {
        public void SearchGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            if ("ASC" == ViewState["sortDirection"].ToString())
            {
                ViewState["sortDirection"] = "DESC";
            }
            else
            {
                ViewState["sortDirection"] = "ASC";
            }
            
            var comodities = this.Data.Comodities.All();
            if (e.SortExpression.StartsWith("Price"))
            {
                if (ViewState["sortDirection"] == "ASC")
                {
                    comodities = comodities.OrderBy(x => x.Price);
                }
                else
                {
                    comodities = comodities.OrderByDescending(x => x.Price);
                }
            }
            else
            {
                if (ViewState["sortDirection"] == "ASC")
                {
                    comodities = comodities.OrderBy(x => x.Name);
                }
                else
                {
                    comodities = comodities.OrderByDescending(x => x.Name);
                }
            }

            this.SearchGrid.DataSource = comodities.ToList();
            this.SearchGrid.DataBind();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ViewState["sortDirection"] = " ";

                this.SearchGrid.DataSource = this.Data.Comodities.All().Include("Author").ToList();
                this.SearchGrid.DataBind();
                
                var categories = this.Data.Categories.All().ToList();
                categories.Insert(0, new Category() { CategoryId = 0, Name = "" });

                this.DropDownListxCategories.DataSource = categories;
                
                this.DropDownListxCategories.DataBind();
            }
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
    }
}