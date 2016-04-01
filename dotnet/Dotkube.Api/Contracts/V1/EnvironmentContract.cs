using System;
using System.Collections;
using Microsoft.Extensions.PlatformAbstractions;

namespace Dotkube.Api.Contracts.V1
{
    public class EnvironmentContract
    {
        public string Hostname { get; set; }

        public IRuntimeEnvironment RuntimeEnvironment { get; set; }
    }
}
