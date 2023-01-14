using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Test.Mapping.Environment.SetUp
{
    public class MappingContext : DbContext
    {
        public MappingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "Tester",
                Password = "heslo123"
            });
        }
    }
}