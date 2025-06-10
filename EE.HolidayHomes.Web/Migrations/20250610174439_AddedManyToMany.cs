using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EE.HolidayHomes.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayHomes_HomeType_HomeTypeId",
                table: "HolidayHomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeType",
                table: "HomeType");

            migrationBuilder.RenameTable(
                name: "HomeType",
                newName: "HomeTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeTypes",
                table: "HomeTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HolidayHomeHomeProperty",
                columns: table => new
                {
                    HolidayHomesId = table.Column<int>(type: "int", nullable: false),
                    HomePropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayHomeHomeProperty", x => new { x.HolidayHomesId, x.HomePropertiesId });
                    table.ForeignKey(
                        name: "FK_HolidayHomeHomeProperty_HolidayHomes_HolidayHomesId",
                        column: x => x.HolidayHomesId,
                        principalTable: "HolidayHomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidayHomeHomeProperty_HomeProperties_HomePropertiesId",
                        column: x => x.HomePropertiesId,
                        principalTable: "HomeProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayHomeHomeProperty_HomePropertiesId",
                table: "HolidayHomeHomeProperty",
                column: "HomePropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayHomes_HomeTypes_HomeTypeId",
                table: "HolidayHomes",
                column: "HomeTypeId",
                principalTable: "HomeTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayHomes_HomeTypes_HomeTypeId",
                table: "HolidayHomes");

            migrationBuilder.DropTable(
                name: "HolidayHomeHomeProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeTypes",
                table: "HomeTypes");

            migrationBuilder.RenameTable(
                name: "HomeTypes",
                newName: "HomeType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeType",
                table: "HomeType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayHomes_HomeType_HomeTypeId",
                table: "HolidayHomes",
                column: "HomeTypeId",
                principalTable: "HomeType",
                principalColumn: "Id");
        }
    }
}
