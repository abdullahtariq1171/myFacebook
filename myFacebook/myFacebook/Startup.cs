using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myFacebook.Startup))]
namespace myFacebook
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
