using System.Collections;

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
    }
}
