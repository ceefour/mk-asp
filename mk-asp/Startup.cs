using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mk_asp.Startup))]
namespace mk_asp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
