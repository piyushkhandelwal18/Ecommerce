using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommonComponent.Startup))]
namespace CommonComponent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
