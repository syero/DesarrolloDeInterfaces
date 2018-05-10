using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatNervionService.Startup))]

namespace ChatNervionService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
            app.MapSignalR();
        }
    }
}