using System;
using System.Collections;
using Microsoft.Extensions.PlatformAbstractions;

namespace Dotkube.Api.Contracts.V1
{
    public class GuestbookEntryContract
    {
        public long Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }
    }
}
