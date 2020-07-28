using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TotemTree.Startup))]
namespace TotemTree
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
