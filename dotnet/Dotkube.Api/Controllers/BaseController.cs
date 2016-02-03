using Microsoft.AspNetCore.Mvc;
using Dotkube.Api.Filters;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Dotkube.Api.Controllers
{
    [InstrumentingFilter]
    public class BaseController : Controller
    {
        public ILogger logger;

        public BaseController(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
