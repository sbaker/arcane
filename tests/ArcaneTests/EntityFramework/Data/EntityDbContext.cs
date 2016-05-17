using Microsoft.Data.Entity;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using ArcaneTests.Models;

namespace ArcaneTests.EntityFramework.Data
{
    public class EntityDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SQLiteConnectionStringBuilder {
                DataSource = "test.db"
            };

            optionsBuilder.UseSqlite(new SqliteConnection(connectionStringBuilder.ToString()));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
