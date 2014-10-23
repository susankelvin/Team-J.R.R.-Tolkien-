namespace Kupuvalnik.WebForms.Admin
{
    using System;
    using System.Linq;
    using System.Threading;

    using Microsoft.AspNet.Identity;

    using BasicPage;
    using Models;
    using Error_Handler_Control;

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
                ErrorSuccessNotifier.AddErrorMessage("You cannot add duplicate categories!");
                return;
            }

            ErrorSuccessNotifier.AddSuccessMessage("You have succesfully added the category!");
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