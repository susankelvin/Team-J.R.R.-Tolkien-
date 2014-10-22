namespace Kupuvalnik.WebForms.Admin
{
    using System;
    using System.Linq;
    using System.Threading;

    using Microsoft.AspNet.Identity;

    using BasicPage;
    using Models;

    public partial class AddCategory : BasePage
    {
        public void AddCategory_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                Name = this.NewCategory.Text
            };
            this.Data.Categories.Add(category);
            try
            {
                this.Data.SaveChanges();
            }
            catch (Exception)
            {
                this.ErrorMessage.Text = "You cannot add duplicate categories!";
                return;
            }

            this.SuccessMessage.Text = "You have succesfully added the category!";
            this.UpdateAllCategoriesData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UpdateAllCategoriesData();
        }

        private void UpdateAllCategoriesData()
        {
            DropDownListxCategories.DataSource = this.Data.Categories.All().ToList();
            DropDownListxCategories.DataBind();
        }
    }
}