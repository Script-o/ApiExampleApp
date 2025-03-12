using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiExampleApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Department = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Research and Development", "nnorgue0@disqus.com", "Nonie", "Norgue" },
                    { 2, "Research and Development", "bborgue0@disqus.com", "Bonie", "Borgue" },
                    { 3, "Research and Development", "wworgue0@disqus.com", "Wonie", "Worgue" },
                    { 4, "Research and Development", "ggorgue0@disqus.com", "Gonie", "Gorgue" },
                    { 5, "Research and Development", "mmorgue0@disqus.com", "Monie", "Morgue" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
