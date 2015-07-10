using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PLCG.Startup))]
namespace PLCG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
