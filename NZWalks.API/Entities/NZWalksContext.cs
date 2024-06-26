using Microsoft.EntityFrameworkCore;
using NZWalks.API.Entities;

namespace NZWalks.API.Data
{
    public class NZWalksContext : DbContext
    {
        public NZWalksContext(DbContextOptions options) : base(options) { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
