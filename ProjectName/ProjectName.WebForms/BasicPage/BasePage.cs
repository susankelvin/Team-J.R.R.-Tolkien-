namespace Kupuvalnik.WebForms.BasicPage
{
    using System;
    using System.Web.UI;

    using App_Data;

    public abstract class BasePage : Page
    {
        protected IKupuvalnikData Data { get; set; }

        public BasePage() : base()
        {
            this.Data = new KupuvalnikData();
        }
    }
}