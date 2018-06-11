using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Actividad.Models;
using Microsoft.Extensions.Configuration; //Extension que se utiliza con IconfigurationRoot
using Microsoft.EntityFrameworkCore;// Extension para conexion con SQL server

namespace Actividad
{
    public class Startup
    {
        //Propiedad para administrar la conexion con el DBMS
        private IConfigurationRoot _ConfigurationRoot;
        //Agregacion del metodo constructor de la clase StartUp para instancia de la conexion
         
            public Startup(IHostingEnvironment hostingEnviroment)
                {
            _ConfigurationRoot = new ConfigurationBuilder()
            .SetBasePath(hostingEnviroment.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .Build();
                }//Fin metodo constructor 


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940


        public void ConfigureServices(IServiceCollection services)
        {
            //registrar el appDBcontext para interactuar con la conexion al DBMS
            services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(_ConfigurationRoot.GetConnectionString("DefaultConnection")));
            //Registrar mis clases repositorios y mock
            //Actualizado por implementacion EFcore
            services.AddTransient<IUsuariosRepositorio, UsuariosRepositorio>();
            services.AddTransient<INivelUsuariosRepositorio, NivelUsuariosRepositorio>();
            //services.AddTransient<INivelUsuariosRepositorio, MockNivelUsuariosRepositorio>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Solicitados>(sp => Solicitados.GetSolicitados(sp));

            //Sporte MVC
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            
            
            app.UseSession();
            app.UseMvc(routes =>
            {


            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
                    
            });
            DataInicio.AgregarData(app);


        }
    }
}
