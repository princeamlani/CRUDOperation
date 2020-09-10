using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CURDoperation.Startup))]
namespace CURDoperation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
