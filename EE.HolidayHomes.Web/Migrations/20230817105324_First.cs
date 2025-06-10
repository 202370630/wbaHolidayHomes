using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EE.HolidayHomes.Web.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayHomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayHomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayHomes_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HomeProperties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rural" },
                    { 2, "Seaside" },
                    { 3, "Luxury" },
                    { 4, "Budget" },
                    { 5, "Family" },
                    { 6, "Business" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lapscheure" },
                    { 2, "Izegem" },
                    { 3, "Blankenberge" },
                    { 4, "Sint-Pieterskapelle" }
                });

            migrationBuilder.InsertData(
                table: "HolidayHomes",
                columns: new[] { "Id", "Image", "LocationId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "house1.jpg", 1, "The Villa", 120.50m },
                    { 2, "house2.jpg", 2, "The Cottage", 250.55m },
                    { 3, "house3.jpg", 3, "The farmhouse", 350.50m },
                    { 4, "house4.jpg", 4, "The seaside house", 350.55m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayHomes_LocationId",
                table: "HolidayHomes",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayHomes");

            migrationBuilder.DropTable(
                name: "HomeProperties");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
