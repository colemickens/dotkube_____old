using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Dotkube.Api;

namespace Dotkube.Tests
{
    public class TestFixture
    {
        public readonly TestServer Server;
        public readonly HttpClient Client;

        public TestFixture()
        {
            var startup = new Startup();

/*
            this.Server = TestServer.Create(
                app => startup.Configure(app),
                (IServiceCollection svcs) => {
                    startup.ConfigureServices(svcs);

                    var testLoggerServiceServiceDescriptor =
                        new ServiceDescriptor(
                            typeof(ILogger),
                            new TestLoggerService());

                    svcs.Replace(testLoggerServiceServiceDescriptor);
                });
*/
            this.Client = this.Server.CreateClient();
        }
    }
}
