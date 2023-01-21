using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Test.BookStore.Environment.SetUp
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<BookTag> BookTags { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = Guid.Parse("6e7c8428-6b49-4c94-b062-af832efd7236"),
                Name = "Bookworm #1",
                Email = "bookworm@author.com"
            });
            modelBuilder.Entity<Publisher>().HasData(new Publisher
            {
                Id = Guid.Parse("5c3b1977-4722-4b3d-9bfb-aeedfd906029"),
                Name = "First Publishing Co."
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.Parse("8117fe29-b4d0-43cd-96cc-3bf9dcf55fda"),
                AuthorId = Guid.Parse("6e7c8428-6b49-4c94-b062-af832efd7236"),
                PublisherId = Guid.Parse("5c3b1977-4722-4b3d-9bfb-aeedfd906029"),
                Title = "Title"
            });
            modelBuilder.Entity<Tag>().HasData(new List<Tag>
            {
                new()
                {
                    Id = 1,
                    Name = "1"
                },
                new()
                {
                    Id = 2,
                    Name = "2"
                }
            });
            modelBuilder.Entity<BookTag>().HasKey(nameof(BookTag.BookId), nameof(BookTag.TagId));
            modelBuilder.Entity<BookTag>().HasData(new List<BookTag>
            {
                new() { BookId = Guid.Parse("8117fe29-b4d0-43cd-96cc-3bf9dcf55fda"), TagId = 2 }
            });
        }
    }
}