using System;
using System.Collections;
using Microsoft.Extensions.PlatformAbstractions;

namespace Dotkube.Api.Contracts.V1
{
    public class CounterContract
    {
        public string Hostname { get; set; }

        public string Shade { get; set; }

        public long InstanceCount { get; set; }

        public long GlobalCount { get; set; }
    }
}
