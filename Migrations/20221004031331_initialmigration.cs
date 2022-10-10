using Microsoft.EntityFrameworkCore.Migrations;

namespace CabManagement.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelManagers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelManagers", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarNumber = table.Column<string>(nullable: true),
                    CarType = table.Column<string>(nullable: true),
                    CarDetails = table.Column<string>(nullable: true),
                    TravelManagerManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_TravelManagers_TravelManagerManagerId",
                        column: x => x.TravelManagerManagerId,
                        principalTable: "TravelManagers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    driverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driverName = table.Column<string>(nullable: true),
                    driverGender = table.Column<string>(nullable: true),
                    driverAge = table.Column<int>(nullable: false),
                    CarsCarId = table.Column<int>(nullable: true),
                    TravelManagerManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.driverId);
                    table.ForeignKey(
                        name: "FK_Drivers_Cars_CarsCarId",
                        column: x => x.CarsCarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_TravelManagers_TravelManagerManagerId",
                        column: x => x.TravelManagerManagerId,
                        principalTable: "TravelManagers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Distance = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: true),
                    TravelManagerManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_Routes_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routes_TravelManagers_TravelManagerManagerId",
                        column: x => x.TravelManagerManagerId,
                        principalTable: "TravelManagers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TravelManagerManagerId",
                table: "Cars",
                column: "TravelManagerManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CarsCarId",
                table: "Drivers",
                column: "CarsCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TravelManagerManagerId",
                table: "Drivers",
                column: "TravelManagerManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CarId",
                table: "Routes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TravelManagerManagerId",
                table: "Routes",
                column: "TravelManagerManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "TravelManagers");
        }
    }
}
