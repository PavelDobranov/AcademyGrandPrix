using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademyGrandPrix.Web.Startup))]

namespace AcademyGrandPrix.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
