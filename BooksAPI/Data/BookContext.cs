using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Data
{
    public class BookContext : DbContext
    {

        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = Book.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(
                 new Author { Id = 1, FirstName = "John", LastName = "Steinbeck", BirthDate = new DateTime(1902, 2, 27) },
                 new Author { Id = 2, FirstName = "Stephen", LastName = "King", BirthDate = new DateTime(1947, 9, 21) }
              );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Viking Press", CountryOfOrigin = "USA", FoundedYear = 1925, HeadQuartersLocation = "NY, NY" },
                new Publisher { Id = 2, Name = "Doubleday", CountryOfOrigin = "USA", FoundedYear = 1897, HeadQuartersLocation = "NY, NY" }
            );

            // TODO: configure some seed data in the books table
            modelBuilder.Entity<Book>().HasData(
               new Book { Id = 1, Title = "The Grapes of Wrath", Genre = "Novel", PublicationYear = 1939, OriginalLanguage = "English", AuthorId = 1, PublisherId = 1 },
               new Book { Id = 2, Title = "Cannery Row", Genre = "Regional", PublicationYear = 1945, OriginalLanguage = "English", AuthorId = 1, PublisherId = 1 },
               new Book { Id = 3, Title = "The Shining", Genre = "Horror", PublicationYear = 1977, OriginalLanguage = "English", AuthorId = 2, PublisherId = 2 }
            );
        }



    }
}
