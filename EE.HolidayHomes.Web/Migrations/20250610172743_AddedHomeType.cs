using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EE.HolidayHomes.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedHomeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeTypeId",
                table: "HolidayHomes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "HolidayHomes",
                keyColumn: "Id",
                keyValue: 1,
                column: "HomeTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HolidayHomes",
                keyColumn: "Id",
                keyValue: 2,
                column: "HomeTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HolidayHomes",
                keyColumn: "Id",
                keyValue: 3,
                column: "HomeTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "HolidayHomes",
                keyColumn: "Id",
                keyValue: 4,
                column: "HomeTypeId",
                value: 3);

            migrationBuilder.InsertData(
                table: "HomeType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cottage" },
                    { 2, "Villa" },
                    { 3, "Appartment" },
                    { 4, "Room" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayHomes_HomeTypeId",
                table: "HolidayHomes",
                column: "HomeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayHomes_HomeType_HomeTypeId",
                table: "HolidayHomes",
                column: "HomeTypeId",
                principalTable: "HomeType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayHomes_HomeType_HomeTypeId",
                table: "HolidayHomes");

            migrationBuilder.DropTable(
                name: "HomeType");

            migrationBuilder.DropIndex(
                name: "IX_HolidayHomes_HomeTypeId",
                table: "HolidayHomes");

            migrationBuilder.DropColumn(
                name: "HomeTypeId",
                table: "HolidayHomes");
        }
    }
}
