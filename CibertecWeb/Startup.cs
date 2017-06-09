using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cibertec.Models;
using Microsoft.EntityFrameworkCore;
using Cibertec.UnitOfWork;

namespace Cibertec
{   //Aca inicia la aplicacion
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder() //configuracion del entorno
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        //se encarga de hacer injeccion de depencia como un servicio
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //injectar como un servicio el dbcontext
            //services.AddDbContext<NorthwindDbContext>(
            //    options => options.UseSqlServer(Configuration.GetConnectionString("Northwind"))
            //    );

            ////genera una instancion por cada peticion (unit of work con EF)
            //services.AddTransient<IUnitOfWork>(
            //    option => new EFUnitOfWork(
            //        new NorthwindDbContext(
            //            new DbContextOptionsBuilder<NorthwindDbContext>()
            //            .UseSqlServer(Configuration.GetConnectionString("Northwind"))
            //            .Options
            //            )
            //        )
            //    );

            //para trabajar con dapper
            services.AddSingleton<IUnitOfWork>(option => new CibertecUnitOfWork(Configuration.GetConnectionString("Northwind")));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
