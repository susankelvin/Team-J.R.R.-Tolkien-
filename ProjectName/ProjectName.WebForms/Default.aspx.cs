namespace Kupuvalnik.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;

    using Kupuvalnik.WebForms.BasicPage;
    using Kupuvalnik.WebForms.Models;

    public partial class _Default : BasePage
    {
        private const string CACHE_ID = "LastOffers";

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Comodity> list = this.Cache[CACHE_ID] as List<Comodity>;
            if (list == null)
            {
                list = this.Data.Comodities.All().Where(c => c.IsApproved == true).OrderByDescending(c => c.DateCreated).Take(10).ToList();
                SqlCacheDependency sqlCacheDependency = new SqlCacheDependency("KupuvalnikDb", "Comodities");
                this.Cache.Insert(CACHE_ID, list, sqlCacheDependency);
            }

            this.LatestOffers.DataSource = list;
            this.LatestOffers.DataBind();
        }
    }
}