using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POS.Web.UI.Startup))]
namespace POS.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
