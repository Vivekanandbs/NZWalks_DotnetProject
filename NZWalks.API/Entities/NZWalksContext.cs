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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePrivilage> RolePrivilages { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
