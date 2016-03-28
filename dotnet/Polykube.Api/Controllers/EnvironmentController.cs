using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Dotkube.Contracts.V1;

namespace Dotkube.Api.Controllers
{
    [Route("/api/environment")]
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

            this.hostname = Environment.MachineName;
        }

        //[VersionGet("api/environment", versionRange: "1")]
        [HttpGet()]
        public EnvironmentContract Index()
        {
            using (this.logger.BeginScopeImpl("Preparing Environment Contract"))
            {
                var environmentContract = new EnvironmentContract()
                {
                    Hostname = this.hostname,
                    RuntimeEnvironment = this.runtimeEnv,
                };

                this.logger.LogInformation("Worked!");

                return environmentContract;
            }
        }
    }
}
