using Microsoft.EntityFrameworkCore;
using ArcaneTests.Models;

namespace ArcaneTests.EntityFramework.Data
{
    internal class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        
        public DbSet<Book> Books { get; set; }
    }
}
