using System.Net.Http;
using System.Net.Http.Formatting;
using Dotkube.Contracts.V1;
using Newtonsoft.Json;
using Xunit;

namespace Dotkube.Tests
{
    public class EndToEndTests : IClassFixture<TestFixture>
    {
        private TestFixture Fixture;

        public EndToEndTests(TestFixture testFixture)
        {
            this.Fixture = testFixture;
        }

        [Fact]
        public async void EnvironmentResource()
        {
            var resp = await this.Fixture.Client.GetAsync("/api/v1/environment");
            var respcontent = await resp.Content.ReadAsAsync<EnvironmentContract>();
            Assert.NotNull(resp);
        }
    }
}
