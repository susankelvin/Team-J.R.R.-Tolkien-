namespace Kupuvalnik.WebForms
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Logic;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Create the custom role and user.
            RoleActions roleActions = new RoleActions();
            roleActions.AddUserAndRole();

            RegisterRoutes(RouteTable.Routes);

            SqlCacheDependencyAdmin.EnableNotifications(ConfigurationManager.ConnectionStrings["KupuvalnikConnectionString"].ConnectionString);
            SqlCacheDependencyAdmin.EnableTableForNotifications(
                ConfigurationManager.ConnectionStrings["KupuvalnikConnectionString"].ConnectionString,
                "Comodities");
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ComodityDetails",
                "{comodityid}",
                "~/ComodityDetails/Details.aspx");

            routes.MapPageRoute("AdminComodityDetails",
                "Admin/{comodityid}",
                "~/ComodityDetails/Details.aspx");
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            //if (HttpContext.Current.Response.Status.StartsWith("500"))
            //{
            //    HttpContext.Current.Response.ClearContent();
            //    Response.Redirect("Unauthorized.aspx");
            //}
        }
    }
}