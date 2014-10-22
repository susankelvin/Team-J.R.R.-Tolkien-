﻿namespace Kupuvalnik.WebForms
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Kupuvalnik.WebForms.BasicPage;
    using Kupuvalnik.WebForms.Models;
    using Microsoft.AspNet.Identity;

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
                    this.ErrorMessage.Text = "Image must be with file extension .jpeg or .png";
                }
            }

            var offer = new Comodity()
            {
                Name = this.Name.Text,
                Description = this.Description.Text,
                Price = decimal.Parse(this.Price.Text),
                AuthorId = currentUserId,
                DateCreated = DateTime.Now,
                CategoryId = int.Parse(this.DropDownListxCategories.SelectedValue),
                ImagePath = string.Format("{0}{1}", directory, filename)
            };
            this.Data.Comodities.Add(offer);
            this.Data.SaveChanges();
            this.SuccessMessage.Text = "You have succesfully created product!";
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