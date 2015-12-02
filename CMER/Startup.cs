using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMER.Startup))]
namespace CMER
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
