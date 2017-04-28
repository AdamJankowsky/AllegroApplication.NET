using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllegroWebAplication.Startup))]
namespace AllegroWebAplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
