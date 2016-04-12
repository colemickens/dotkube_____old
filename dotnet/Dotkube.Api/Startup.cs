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
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using Dotkube.Api.Controllers;
using Dotkube.Api.DataAccess;

namespace Dotkube.Api
{
    public class Startup
    {
        private IConfiguration Configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("config.json");
            configBuilder.AddEnvironmentVariables();
            this.Configuration = configBuilder.Build();

            services.AddOptions();
            services.Configure<DotkubeOptions>(this.Configuration);

            services.AddTransient<IDatabase>((IServiceCollection) => configureRedis());
            services.AddDbContext<DataContext>(options => configureDatabase(options));
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

        private DbContextOptionsBuilder configureDatabase(DbContextOptionsBuilder options)
        {
            var profile = this.Configuration["database:profile"];
            var driver = this.Configuration[$"database-{profile}:driver"];

            var server = this.Configuration[$"database-{profile}:server"];
            var port = this.Configuration[$"database-{profile}:port"];
            var database = this.Configuration[$"database-{profile}:database"];
            var username = this.Configuration[$"database-{profile}:username"];
            var password = this.Configuration[$"database-{profile}:password"]; // read from secret in container, or "default" otherwise

            // can I get a logger here? I'm probably wrong for wanting that too...
            Console.WriteLine("database profile = {0}", profile);
            Console.WriteLine("database driver = {0}", driver);
            Console.WriteLine("database server = {0}", server);
            Console.WriteLine("database port = {0}", port);
            Console.WriteLine("database database = {0}", database);
            Console.WriteLine("database username = {0}", username);
            Console.WriteLine("database password = {0}", password);

            switch(driver)
            {
                case "mssql":
                {
                    var connectionString = $"Server={server};Database={database};User={username};Password={password};";
                    Console.WriteLine("datbase connectionString = {0}", connectionString);
                    return options.UseSqlServer(connectionString);
                }
                case "pgsql":
                {
                    var connectionString = $"server={server};user id={username};password={password};database={database}";
                    Console.WriteLine("datbase connectionString = {0}", connectionString);
                    throw new InvalidOperationException("npsql doesn't work yet");
                    //return options.UseNpgsql(connectionString);
                }
                case "mem":
                case "memory":
                default:
                    return options.UseInMemoryDatabase();
            }
        }

        private IDatabase configureRedis()
        {
            var connectionOutput = new StringWriter();
            try {
                var server = this.Configuration["redis:server"];
                var port = this.Configuration["redis:port"];

                var connectionString = this.Configuration["redis:server"]
                    + ":" + this.Configuration["redis:port"];

                Console.WriteLine("redis server = {0}", server);
                Console.WriteLine("redis port = {0}", port);
                Console.WriteLine("redis connectionString = {0}", connectionString);

                var redis = ConnectionMultiplexer.Connect(connectionString, connectionOutput);
                var db = redis.GetDatabase();

                return db;
            }
            catch (Exception)
            {
                Console.Error.WriteLine(connectionOutput.ToString());
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
