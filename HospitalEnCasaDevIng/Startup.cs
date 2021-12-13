using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalEnCasaDevIng.Startup))]
namespace HospitalEnCasaDevIng
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
