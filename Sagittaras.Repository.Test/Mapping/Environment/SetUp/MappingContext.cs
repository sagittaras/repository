using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Test.Mapping.Environment.SetUp
{
    public class MappingContext(DbContextOptions options) : DbContext(options)
    {
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