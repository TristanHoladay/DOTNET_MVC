using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Category", "Title" },
                values: new object[] { 1, "Author 1", "Fiction", "The Grapes of Wrath" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Category", "Title" },
                values: new object[] { 2, "Author 2", "Fiction", "Cannery Row" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Category", "Title" },
                values: new object[] { 3, "Author 3", "Fiction", "The Shining" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
