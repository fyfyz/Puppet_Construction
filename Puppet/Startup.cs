using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Puppet.Startup))]
namespace Puppet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
