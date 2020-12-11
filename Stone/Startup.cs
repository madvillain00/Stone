using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stone.Startup))]
namespace Stone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
