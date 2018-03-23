using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeBlog.Startup))]
namespace RecipeBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
