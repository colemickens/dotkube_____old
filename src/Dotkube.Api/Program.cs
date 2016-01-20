using System.IO;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;

namespace Dotkube.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var app = new WebHostBuilder()
				.UseServer("Microsoft.AspNet.Server.Kestrel")
				.UseApplicationBasePath(Directory.GetCurrentDirectory())
				.UseStartup<Startup>()
				.Build();

			app.Run();
		}
	}
}
