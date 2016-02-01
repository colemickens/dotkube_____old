using System;
using System.Collections;
using Microsoft.Extensions.PlatformAbstractions;

namespace Dotkube.Contracts.V1
{
    public class EnvironmentContract
    {
        public string Hostname { get; set; }

        public string OperatingSystem { get; set; }

        public string OperatingSystemVersion { get; set; }

        public string RuntimeArchitecture { get; set; }

        public string RuntimeType { get; set; }

        public string RuntimeVersion { get; set; }

        public IDictionary EnvironmentVariables { get; set; }

        public IRuntimeEnvironment RuntimeEnvironment { get; set; }
    }
}
