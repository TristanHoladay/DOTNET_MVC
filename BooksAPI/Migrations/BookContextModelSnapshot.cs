﻿// <auto-generated />
using System;
using BooksAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksAPI.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("BooksAPI.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1902, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Steinbeck"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Stephen",
                            LastName = "King"
                        });
                });

            modelBuilder.Entity("BooksAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Genre");

                    b.Property<string>("OriginalLanguage");

                    b.Property<int>("PublicationYear");

                    b.Property<int>("PublisherId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Genre = "Novel",
                            OriginalLanguage = "English",
                            PublicationYear = 1939,
                            PublisherId = 1,
                            Title = "The Grapes of Wrath"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Genre = "Regional",
                            OriginalLanguage = "English",
                            PublicationYear = 1945,
                            PublisherId = 1,
                            Title = "Cannery Row"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Genre = "Horror",
                            OriginalLanguage = "English",
                            PublicationYear = 1977,
                            PublisherId = 2,
                            Title = "The Shining"
                        });
                });

            modelBuilder.Entity("BooksAPI.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryOfOrigin");

                    b.Property<int>("FoundedYear");

                    b.Property<string>("HeadQuartersLocation");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryOfOrigin = "USA",
                            FoundedYear = 1925,
                            HeadQuartersLocation = "NY, NY",
                            Name = "Viking Press"
                        },
                        new
                        {
                            Id = 2,
                            CountryOfOrigin = "USA",
                            FoundedYear = 1897,
                            HeadQuartersLocation = "NY, NY",
                            Name = "Doubleday"
                        });
                });

            modelBuilder.Entity("BooksAPI.Models.Book", b =>
                {
                    b.HasOne("BooksAPI.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BooksAPI.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
