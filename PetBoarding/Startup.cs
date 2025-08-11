using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AF.PetBoarding.Startup))]
namespace AF.PetBoarding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
