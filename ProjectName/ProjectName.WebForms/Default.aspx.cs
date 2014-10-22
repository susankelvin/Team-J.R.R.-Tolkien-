using Kupuvalnik.WebForms.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kupuvalnik.WebForms
{
    public partial class _Default : Page
    {
        IKupuvalnikData data = new KupuvalnikData();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LatestOffers.DataSource = data.Comodities.All().OrderByDescending(c => c.DateCreated).Take(10).ToList();
            this.LatestOffers.DataBind();

        }
    }
}