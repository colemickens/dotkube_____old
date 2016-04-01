using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Dotkube.Api.Contracts.V1;
using Dotkube.Api.DataAccess;
using Dotkube.Api.Models;

namespace Dotkube.Api.Controllers
{
    [Route("/api/counter")]
    public class CounterController : BaseController
    {
        private const string ColorBase = "blue";
        private const int GlobalCounterId = 1000;

        private DataContext dataContext;

        public CounterController(ILoggerFactory loggerFactory, DataContext dataContext)
            : base(loggerFactory.CreateLogger(nameof(CounterController)))
        {
            this.dataContext = dataContext;
        }

        [HttpGet()]
        public CounterContract Index(int counterId)
        {
            var demoResponse = new CounterContract
            {
                Hostname = Environment.MachineName,
                Shade = getShade(),
                InstanceCount = getInstanceCount(),
                GlobalCount = getGlobalCount(),
            };

            return demoResponse;
        }

        private long getGlobalCount() {
            return 1000;
        }

        private long getInstanceCount() {
            return Interlocked.Increment(ref Instance.CounterValue);
        }

        private string getShade() {
            return ColorBase;
        }
    }
}
