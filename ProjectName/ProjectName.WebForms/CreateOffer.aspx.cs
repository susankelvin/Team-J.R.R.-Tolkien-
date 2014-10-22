namespace Kupuvalnik.WebForms
{
    using System;
    using System.Linq;
    using System.Threading;

    using Microsoft.AspNet.Identity;

    using Kupuvalnik.WebForms.BasicPage;
    using Kupuvalnik.WebForms.Models;


    public partial class CreateOffer : BasePage
    {
        public void CreateOffer_Click(object sender, EventArgs e)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();
            if (currentUserId == null)
            {
                this.ErrorMessage.Text = "You must log in in order to publish an offer!";
                return;
            }

            var category = new Category()
            {
                Name = "Stuff "+new Random().Next(1,1000)
            };
            this.Data.Categories.Add(category);
            this.Data.SaveChanges();

            var offer = new Comodity()
            {
                Name = this.Name.Text,
                Description = this.Description.Text,
                Price = decimal.Parse(this.Price.Text),
                AuthorId = currentUserId,
                DateCreated=DateTime.Now,
                CategoryId = int.Parse(this.DropDownListxCategories.SelectedValue)
            };
            this.Data.Comodities.Add(offer);
            this.Data.SaveChanges();
            this.SuccessMessage.Text = "You have succesfully created product!";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownListxCategories.DataSource = this.Data.Categories.All().ToList();
            DropDownListxCategories.DataBind();
        }
    }
}