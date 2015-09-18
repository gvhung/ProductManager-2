using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProdMan.Startup))]
namespace ProdMan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
