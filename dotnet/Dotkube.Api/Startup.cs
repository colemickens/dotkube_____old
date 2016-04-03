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
        public void ConfigureServices(IServiceCollection services)
        {
            // nasty, avoids dead code warning though
            var useMssql = (DateTime.Now > new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
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
                var password = "password"; // read from secret in container, or "default" otherwise
                var connectionString = $"server={server};user id={user};password={password};database={database}";
                //services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
            }
            services
                .AddMvcCore()
                .AddJsonFormatters();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, DataContext dataContext)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddEnvironmentVariables();
            var config = configBuilder.Build();

            initDatabase(dataContext);
            Console.WriteLine("init db done");

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
