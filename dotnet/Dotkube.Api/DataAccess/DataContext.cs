using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dotkube.Api.Models;

namespace Dotkube.Api.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CounterModel> Counters { get; set; }
        public DbSet<GuestbookEntry> GuestbookEntries { get; set; }
    }
}
