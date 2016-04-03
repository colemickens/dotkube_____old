using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
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
        //[FromServices]
        private DataContext dataContext;

        public GuestbookEntryController(ILoggerFactory loggerFactory, DataContext dataContext)
            : base(loggerFactory.CreateLogger(nameof(GuestbookEntryController)))
        {
            this.dataContext = dataContext;
        }

        [HttpGet()]
        public async Task<List<GuestbookEntryContract>> List() {
            var dbEntries = this.dataContext.GuestbookEntries
                .OrderBy(e => e.Timestamp);

            var entries = await dbEntries.Select(e => new GuestbookEntryContract{
                Title = e.Title,
                Author = e.Author,
                Message = e.Message,
                Timestamp = e.Timestamp,
            }).ToListAsync();;

            return entries;
        }

        [HttpGet("{id}")]
        public GuestbookEntryContract Get(string id) {
            return null;
        }

        [HttpPost]
        public void Post(
            [FromBody]
            GuestbookEntryContract entry)
        {

        }
    }
}
