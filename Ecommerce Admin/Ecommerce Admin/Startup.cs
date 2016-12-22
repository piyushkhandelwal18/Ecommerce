using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ecommerce_Admin.Startup))]
namespace Ecommerce_Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
