namespace Kupuvalnik.WebForms.ComodityDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Kupuvalnik.WebForms.BasicPage;
    using Kupuvalnik.WebForms.Models;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    
    public partial class Details : BasePage
    {
        public Comodity Comodity { get; set; }

        public void CreateComment_Click(object sender, EventArgs e)
        {
            var comment = new Comment()
            {
                AuthorId = Thread.CurrentPrincipal.Identity.GetUserId(),
                DateCreated = DateTime.Now,
                ComodityId = int.Parse(Page.RouteData.Values["comodityid"].ToString()),
                Text = this.CommentText.Text
            };
            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int currentComodityId = 0;
            try
            {
                currentComodityId = int.Parse(Page.RouteData.Values["comodityid"].ToString());
            }
            catch (Exception)
            {
                Response.Redirect("/");
            }

            this.Comodity = this.Data.Comodities.All().FirstOrDefault(c => c.ComodityId == currentComodityId);
            if (this.Comodity == null)
            {
                Response.Redirect("/");
            }
            
            this.ComodityImage.ImageUrl = this.Comodity.ImagePath;
            this.ComodityImage.DataBind();
        }
        
        public IEnumerable<Comment> CommentsView_GetData([Control]
                                                         int? commentId)
        {
            var currentComodityId = int.Parse(Page.RouteData.Values["comodityid"].ToString());
            return this.Data.Comments.All().Where(c => c.ComodityId == currentComodityId).OrderByDescending(c=>c.DateCreated).ToList();
        }
    }
}