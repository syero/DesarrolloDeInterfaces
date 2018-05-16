using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AltoLapizService.Startup))]

namespace AltoLapizService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);

            app.MapSignalR(); //mapeo a signalR
        }
    }
}