using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeDemo.Startup))]
namespace PracticeDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
