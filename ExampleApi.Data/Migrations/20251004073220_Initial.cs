using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExampleApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "BirthDate", "Created", "Deleted", "Firstname", "Lastname", "Updated" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "123 Main Street, Bangkok", new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 7, 32, 19, 765, DateTimeKind.Utc).AddTicks(9650), null, "John", "Doe", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "456 Second Avenue, Chiang Mai", new DateTime(1985, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 7, 32, 19, 765, DateTimeKind.Utc).AddTicks(9780), null, "Jane", "Smith", null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "789 Sukhumvit Road, Bangkok", new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 4, 7, 32, 19, 765, DateTimeKind.Utc).AddTicks(9790), null, "Somchai", "Prasert", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
