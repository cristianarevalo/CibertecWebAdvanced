using Owin;
using System.Web.Http;
using Cibertec.RealTime.App_Start;
using Microsoft.Owin.Cors;

namespace Cibertec.RealTime
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll); //Permitir todas las comunicacion

            var httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            app.MapSignalR();
            app.UseWebApi(httpConfig);
        }
    }
}
