using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    FoundedYear = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    HeadQuartersLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    OriginalLanguage = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    PublicationYear = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1902, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Steinbeck" });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen", "King" });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "Id", "CountryOfOrigin", "FoundedYear", "HeadQuartersLocation", "Name" },
                values: new object[] { 1, "USA", 1925, "NY, NY", "Viking Press" });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "Id", "CountryOfOrigin", "FoundedYear", "HeadQuartersLocation", "Name" },
                values: new object[] { 2, "USA", 1897, "NY, NY", "Doubleday" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 1, 1, "Novel", "English", 1939, 1, "The Grapes of Wrath" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 2, 1, "Regional", "English", 1945, 1, "Cannery Row" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 3, 2, "Horror", "English", 1977, 2, "The Shining" });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_PublisherId",
                table: "books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
