using System;
using Dotkube.Api.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Xunit;

namespace Dotkube.Tests
{
	public class ControllerUnitTests
	{
		ILogger logger;
		ILoggerFactory loggerFactory;
		IRuntimeEnvironment runtimeEnvironment;

		public ControllerUnitTests(IRuntimeEnvironment runtimeEnvironment)
		{
			this.runtimeEnvironment = runtimeEnvironment;
		}

		[Fact]
		public void TestEnvironmentController()
		{
			var environmentController = new EnvironmentController(
				this.loggerFactory,
				this.runtimeEnvironment);

			var resp = environmentController.Index();

			Assert.NotNull(resp);
		}
	}
}
