using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel;

namespace Dotkube.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var server = typeof(KestrelServer).GetTypeInfo().Assembly.FullName;

			var host = new WebHostBuilder()
				.UseServer(server)
				.UseUrls(new[]{ "http://0.0.0.0:9010" })
				//.UseApplicationBasePath(Directory.GetCurrentDirectory())
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
