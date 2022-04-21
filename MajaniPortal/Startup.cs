using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MajaniPortal.Startup))]
namespace MajaniPortal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
