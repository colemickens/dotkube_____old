using System;

namespace Dotkube.Api
{
    public class DotkubeOptions
    {
        public string DatabaseProvider { get; set; }

		public string DatabaseServer { get; set; }

		public int DatabasePort { get; set; }

		public string DatabaseUsername { get; set; }

		public string DatabasePassword { get; set; }

        public string RedisServer { get; set; }

		public int RedisPort { get; set; }
    }
}
