using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Store.Startup))]
namespace Web_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
