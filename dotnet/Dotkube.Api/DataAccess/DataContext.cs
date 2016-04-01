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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Counter>().Property(x => x.Id).ValueGeneratedNever();
        }

        public DbSet<Counter> Counters { get; set; }
    }
}
