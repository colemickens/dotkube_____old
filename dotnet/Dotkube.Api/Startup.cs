using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Dotkube.Api.Controllers;
using Dotkube.Api.DataAccess;

namespace Dotkube.Api
{
    public class Startup
    {
        // TODO: How to consume the Configuration? Inject with IOptions<DotkubeOptions>
        // but how to consume it now before I can use the injection?

        public void ConfigureServices(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("config.json");
            configBuilder.AddEnvironmentVariables();
            var config = configBuilder.Build();

			// how does this handle parsing of env vars into my typed options obj
            services.AddOptions();
            services.Configure<DotkubeOptions>(config);

            services.AddTransient<IDatabase>((IServiceCollection) => configureRedis(dotkubeOptions));
            services.AddDbContext<DataContext>(options => configureDatabase(dotkubeOptions, options));
            services.AddMvcCore().AddJsonFormatters();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, DataContext dataContext, IDatabase redisDb)
        {
            loggerFactory.AddConsole();

            ensureDatabase(dataContext);
            ensureRedis(redisDb);

            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();

            app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod());
            app.UseMvc();
        }

        private DbContextOptionsBuilder configureDatabase(DotkubeOptions dotkubeOptions, DbContextOptionsBuilder options)
        {
            switch(dotkubeOptions.DatabaseProvider)
            {
                case "mssql":
                {
                    var server = "mssqldb";
                    server = "172.17.0.1";
                    var database = "dotkubedb";
                    var user = "sa";
                    var password = "password"; // read from secret in container, or "default" otherwise
                    var connectionString = $"Server={server};Database={database};User={user};Password={password};";
                    return options.UseSqlServer(connectionString);
                }
                case "pgsql":
                {
                    var server = "pgsql";
                    server = "172.17.0.1";
                    var database = "dotkubedb";
                    var user = "postgres";
                    var password = "password"; // read from secret in container, or "default" otherwise
                    var connectionString = $"server={server};user id={user};password={password};database={database}";
                    throw new InvalidOperationException("npsql doesn't work yet");
                    //return options.UseNpgsql(connectionString);
                }
                case "mem":
                case "memory":
                default:
                    return options.UseInMemoryDatabase();
            }
        }

        private IDatabase configureRedis(DotkubeOptions dotkubeOptions)
        {
            var connectionOutput = new StringWriter();
            try {
                var redisServer = dotkubeOptions.RedisServer+":6379";
                //redisServer = "azdev.mickens.io:6379";
                //redisServer = "52.160.106.19:6379";

                var redis = ConnectionMultiplexer.Connect(redisServer, connectionOutput);
                var db = redis.GetDatabase();

                return db;
            }
            catch (Exception)
            {
                Console.WriteLine(connectionOutput.ToString());
                throw;
            }
        }

        private void ensureDatabase(DataContext dataContext)
        {
            dataContext.Database.EnsureCreatedAsync().Wait();
        }

        private void ensureRedis(IDatabase db)
        {
            db.StringSet("testkey", "testvalue");
            byte[] value = db.StringGet("testkey");
            Console.WriteLine("got from redis: %s", value);
        }
    }
}
