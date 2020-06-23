using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CharcoalCompanion.MVC.Startup))]
namespace CharcoalCompanion.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
