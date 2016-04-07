using System;
using System.Collections;
using Microsoft.Extensions.PlatformAbstractions;

namespace Dotkube.Api.Contracts.V1
{
    public class GuestbookEntryContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }
    }
}
