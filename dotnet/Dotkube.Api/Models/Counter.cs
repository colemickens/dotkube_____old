using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dotkube.Api.Models
{
    public class Counter
    {
        [Key]
        public int Id { get; set; }

        public long Value { get; set; }
    }
}
