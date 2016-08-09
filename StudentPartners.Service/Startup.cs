using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StudentPartners.Service.Startup))]

namespace StudentPartners.Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}