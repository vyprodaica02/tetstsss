using LoginWithGoogAutheries.Entity;
using Microsoft.EntityFrameworkCore;

namespace LoginWithGoogAutheries.Infrastructure
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Integrated Security=true;Initial Catalog=LoginGG;MultipleActiveResultSets=True;encrypt=true;trustservercertificate=true");
        }
        public DbSet<User> Users { get; set; }
    }
}
