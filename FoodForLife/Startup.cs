using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodForLife.Startup))]
namespace FoodForLife
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
