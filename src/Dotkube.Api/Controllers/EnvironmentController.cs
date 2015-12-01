using System;
using Microsoft.Dnx.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Dotkube.Contracts.V1;

namespace Dotkube.Api.Controllers
{
    public class EnvironmentController : BaseController
    {
        private string hostname;
        private IRuntimeEnvironment runtimeEnv;

        public EnvironmentController(
            ILoggerFactory loggerFactory,
            IRuntimeEnvironment runtimeEnv)
            : base(loggerFactory.CreateLogger(nameof(EnvironmentController)))
        {
            this.runtimeEnv = runtimeEnv;
            this.hostname = "RandomHostname";
        }

        public EnvironmentContract Index()
        {
            using (this.logger.BeginScopeImpl("Preparing Environment Contract"))
            {
                var environmentContract = new EnvironmentContract()
                {
                    Hostname = this.hostname,
                    OperatingSystem = this.runtimeEnv.OperatingSystem,
                    OperatingSystemVersion = this.runtimeEnv.OperatingSystemVersion,
                    RuntimeArchitecture = this.runtimeEnv.RuntimeArchitecture,
                    RuntimeType = this.runtimeEnv.RuntimeType,
                    RuntimeVersion = this.runtimeEnv.OperatingSystem,
                    EnvironmentVariables = Environment.GetEnvironmentVariables(),
                };

                this.logger.LogInformation("Worked!");

                return environmentContract;
            }
        }
    }
}
