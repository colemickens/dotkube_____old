using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Strathweb.TypedRouteProvider;
using Dotkube.Api.Controllers;

namespace Dotkube.Api
{
    public class Startup
    {
        public void ConfigureStaticRoutes(MvcOptions opt)
        {
            opt.EnableTypedRouting();

            opt.GetRoute(
                "api/v1/environment",
                c => c.Action<EnvironmentController>(
                    x => x.Index()));

            opt.GetRoute(
                "api/v1/sha256",
                c => c.Action<TestSha256Controller>(
                    x => x.Index(Param<string>.Any)));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.Configure<MvcOptions>(opt => ConfigureStaticRoutes(opt));
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
