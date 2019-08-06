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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = Book.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Grapes of Wrath", Author = "Author 1", Category = "Fiction" },
                new Book { Id = 2, Title = "Cannery Row", Author = "Author 2", Category = "Fiction" },
                new Book { Id = 3, Title = "The Shining", Author = "Author 3", Category = "Fiction" }
                );
        }



    }
}
