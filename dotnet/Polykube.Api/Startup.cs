using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using AspNet.Mvc.TypedRouting;
using Dotkube.Api.Controllers;

namespace Dotkube.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddJsonFormatters()
                .AddControllersAsServices(typeof(Startup).GetTypeInfo().Assembly);
            services.AddCors();

            /*
             * TODO: resurrect this eventually, when the time is right (aka, shit stabilizes)
            services.AddMvc().AddTypedRouting(routes => {
                routes.Get("api/v1/environment", route =>
                    route.ToAction<EnvironmentController>(c =>
                            c.Index()));

                routes.Get("api/v1/sha256", route =>
                    route.ToAction<Sha256Controller>(c =>
                        c.Index(Microsoft.AspNet.Builder.With.Any<string>())));
            });
            */
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod());
            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}
