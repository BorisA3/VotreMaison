using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaisonVotre.Startup))]
namespace MaisonVotre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
