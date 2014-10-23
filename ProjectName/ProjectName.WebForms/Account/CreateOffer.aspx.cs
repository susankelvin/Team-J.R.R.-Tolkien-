namespace Kupuvalnik.WebForms
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Kupuvalnik.WebForms.BasicPage;
    using Kupuvalnik.WebForms.Models;
    using Microsoft.AspNet.Identity;

    using Error_Handler_Control;

    public partial class CreateOffer : BasePage
    {
        public void CreateOffer_Click(object sender, EventArgs e)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();
            if (currentUserId == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("You must log in in order to publish an offer!");
                return;
            }
            
            string filename = "";
            string directory = "~/Uploaded_Files/";
            if (this.FileUploadControl.HasFile)
            {
                if (this.FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                    this.FileUploadControl.PostedFile.ContentType == "image/jpg" ||
                    this.FileUploadControl.PostedFile.ContentType == "image/png")
                {
                    filename = Path.GetFileName(this.FileUploadControl.FileName);
                    this.FileUploadControl.SaveAs(string.Format("{0}{1}", this.Server.MapPath(directory), filename));
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("Image must be with file extension .jpeg or .png");
                    return;
                }
            }
            decimal currentPrice = 0;
            try
            {
                currentPrice = decimal.Parse(this.Price.Text);
            }
            catch (Exception)
            {
                ErrorSuccessNotifier.AddErrorMessage("Please enter a decimal floating point number for the `price` field!");
                return;
            }
            var offer = new Comodity()
            {
                Name = this.Name.Text,
                Description = this.Description.Text,
                Price = currentPrice,
                AuthorId = currentUserId,
                DateCreated = DateTime.Now,
                CategoryId = int.Parse(this.DropDownListxCategories.SelectedValue),
                ImagePath = string.Format("{0}{1}", directory, filename)
            };
            this.Data.Comodities.Add(offer);
            this.Data.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("You have succesfully created product!");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DropDownListxCategories.DataSource = this.Data.Categories.All().ToList();
                this.DropDownListxCategories.DataBind();
            }
        }
    }
}