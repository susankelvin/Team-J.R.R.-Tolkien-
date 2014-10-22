using System;
using System.Linq;
using System.Threading;
using Kupuvalnik.WebForms.App_Data;
using Kupuvalnik.WebForms.Models;
using Microsoft.AspNet.Identity;

namespace Kupuvalnik.WebForms
{
    public partial class CreateOffer : System.Web.UI.Page
    {
        private static IKupuvalnikData data = new KupuvalnikData();

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
            data.Categories.Add(category);
            data.SaveChanges();

            var offer = new Comodity()
            {
                Name = this.Name.Text,
                Description = this.Description.Text,
                Price = decimal.Parse(this.Price.Text),
                AuthorId = currentUserId,
                DateCreated=DateTime.Now,
                CategoryId = int.Parse(this.DropDownListxCategories.SelectedValue)
            };
            data.Comodities.Add(offer);
            data.SaveChanges();
            this.SuccessMessage.Text = "You have succesfully created product!";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownListxCategories.DataSource = data.Categories.All().ToList();
            DropDownListxCategories.DataBind();
        }
    }
}