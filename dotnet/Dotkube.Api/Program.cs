using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.EntityFrameworkCore;
using Dotkube.Api.DataAccess;

namespace Dotkube.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var server = typeof(KestrelServer).GetTypeInfo().Assembly.FullName;

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(new[]{ "http://0.0.0.0:8000" })
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
