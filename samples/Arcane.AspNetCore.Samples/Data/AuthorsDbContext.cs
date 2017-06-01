using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Arcane.Data;
using Microsoft.EntityFrameworkCore;

namespace Arcane.AspNetCore.Samples.Data
{
    public class AuthorsDbContext : DbContext
    {
        public AuthorsDbContext(DbContextOptions<AuthorsDbContext> options) : base(options)
        {
        }

        /// <summary>
        ///     Override this method to further configure the model that was discovered by convention from the entity types
        ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        ///     and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <remarks>
        ///     If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        ///     then this method will not be run.
        /// </remarks>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
        ///     define extension methods on this object that allow you to configure aspects of the model that are specific
        ///     to a given database.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
    }

    public class Author : DataStoreEntity<int, Author>
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }

    public class Book : DataStoreEntity<int, Book>
    {
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public string Name { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
