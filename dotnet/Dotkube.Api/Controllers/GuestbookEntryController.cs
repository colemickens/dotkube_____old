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
    [Route("/api/guestbookentry")]
    public class GuestbookEntryController : BaseController
    {
        private DataContext dataContext;

        public GuestbookEntryController(ILoggerFactory loggerFactory, DataContext dataContext)
            : base(loggerFactory.CreateLogger(nameof(GuestbookEntryController)))
        {
            this.dataContext = dataContext;
        }

        [HttpGet()]
        public GuestbookEntryContract[] List() {
            return new GuestbookEntryContract[]{};
        }

        [HttpGet()]
        public GuestbookEntryContract Get(string id) {
            return null;
        }
    }
}
