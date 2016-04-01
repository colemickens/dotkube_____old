using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Dotkube.Api.Controllers;
using Dotkube.Api.DataAccess;

namespace Dotkube.Api
{
    public class Startup
    {
        private const bool useMssql = true;

        public void ConfigureServices(IServiceCollection services)
        {
            if (useMssql)
            {
                var server = "mssqldb";
                server = "172.17.0.1";
                var database = "dotkubedb";
                var user = "sa";
                var password = "password"; // read from secret in container, or "default" otherwise
                var connectionString = $"Server={server};Database={database};User={user};Password={password};";
                services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            }
            else
            {
                var server = "pgsql";
                server = "172.17.0.1";
                var database = "dotkubedb";
                var user = "postgres";
                var connectionString = $"server={server};user id={user};password={password};database={database}";
                //services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
            }
            services
                .AddMvcCore()
                .AddJsonFormatters()
                .AddControllersAsServices(typeof(Startup).GetTypeInfo().Assembly);

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, DataContext dataContext)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddEnvironmentVariables();
            var config = configBuilder.Build();

            Console.WriteLine("before <<<<<<<<<<<<<<<<<<<<");
            initDatabase(dataContext);
            Console.WriteLine("after  >>>>>>>>>>>>>>>>>>>>");

            loggerFactory.AddConsole();

            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();

            app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod());
            app.UseMvc();
        }

        private void initDatabase(DataContext dataContext)
        {
            dataContext.Database.EnsureCreatedAsync().Wait();
        }
    }
}