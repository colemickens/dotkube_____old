using System.IO;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;

namespace Dotkube
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var config = WebApplicationConfiguration.GetDefault(args);

			var app = new WebApplicationBuilder()
				.UseServer("Microsoft.AspNet.Server.Kestrel")
				.UseApplicationBasePath(Directory.GetCurrentDirectory())
				.UseConfiguration(config)
				.UseStartup<Startup>()
				.Build();

			app.Run();
		}
	}
}
