using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Insurance.Startup))]
namespace Insurance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}