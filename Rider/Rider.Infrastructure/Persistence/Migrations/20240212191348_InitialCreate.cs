using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rider.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiderDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RiderDetails",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "1645, Alabama", "John Doe" },
                    { 2, "1646, Alabama", "John Peter" },
                    { 3, "1647, Alabama", "Peter Joe" },
                    { 4, "1648, Alabama", "Jane Foster" },
                    { 5, "1649, Alabama", "Daniel Kraig" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiderDetails");
        }
    }
}
