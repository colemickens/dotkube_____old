using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dotkube.Api.Models
{
    public class GuestbookEntry
    {
        [Key]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }
    }
}
