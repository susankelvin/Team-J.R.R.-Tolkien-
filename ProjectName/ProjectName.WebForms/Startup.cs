using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kupuvalnik.WebForms.Startup))]
namespace Kupuvalnik.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
