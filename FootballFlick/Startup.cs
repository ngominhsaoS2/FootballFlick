using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootballFlick.Startup))]
namespace FootballFlick
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
