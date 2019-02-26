using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsParserSite.WEB.Startup))]
namespace NewsParserSite.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
