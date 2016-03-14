using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningWebsite.Startup))]
namespace LearningWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
