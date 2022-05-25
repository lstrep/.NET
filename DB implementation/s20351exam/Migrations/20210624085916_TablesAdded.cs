using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace s20351Retake.Migrations
{
    public partial class TablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Confectioneries",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerOne = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectioneries", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrders",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrders", x => x.IdClientOrder);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Employees_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery_ClientOrders",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false),
                    IdConfectionery = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_ClientOrders", x => new { x.IdClientOrder, x.IdConfectionery });
                    table.ForeignKey(
                        name: "FK_Confectionery_ClientOrders_ClientOrders_IdClientOrder",
                        column: x => x.IdClientOrder,
                        principalTable: "ClientOrders",
                        principalColumn: "IdClientOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionery_ClientOrders_Confectioneries_IdConfectionery",
                        column: x => x.IdConfectionery,
                        principalTable: "Confectioneries",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Bartek", "Bartkowski" },
                    { 2, "Tomek", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Confectioneries",
                columns: new[] { "IdConfectionery", "Name", "PricePerOne" },
                values: new object[,]
                {
                    { 1, "Confectionery 1", 50f },
                    { 2, "Confectionery 2", 100f }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "IdEmployee", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Michał", "Michaulowski" },
                    { 2, "Krzys", "Krzysiowski" }
                });

            migrationBuilder.InsertData(
                table: "ClientOrders",
                columns: new[] { "IdClientOrder", "Comments", "CompletionDate", "IdClient", "IdEmployee", "OrderDate" },
                values: new object[] { 1, "Some comments", new DateTime(2021, 6, 27, 10, 59, 16, 248, DateTimeKind.Local).AddTicks(3832), 1, 1, new DateTime(2021, 6, 24, 10, 59, 16, 246, DateTimeKind.Local).AddTicks(2097) });

            migrationBuilder.InsertData(
                table: "ClientOrders",
                columns: new[] { "IdClientOrder", "Comments", "CompletionDate", "IdClient", "IdEmployee", "OrderDate" },
                values: new object[] { 2, "Some comments", new DateTime(2021, 6, 29, 10, 59, 16, 248, DateTimeKind.Local).AddTicks(5642), 2, 2, new DateTime(2021, 6, 24, 10, 59, 16, 248, DateTimeKind.Local).AddTicks(5628) });

            migrationBuilder.InsertData(
                table: "Confectionery_ClientOrders",
                columns: new[] { "IdClientOrder", "IdConfectionery", "Amount", "Comments" },
                values: new object[] { 1, 1, 30, "comments" });

            migrationBuilder.InsertData(
                table: "Confectionery_ClientOrders",
                columns: new[] { "IdClientOrder", "IdConfectionery", "Amount", "Comments" },
                values: new object[] { 2, 2, 500, "comments" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_IdClient",
                table: "ClientOrders",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_IdEmployee",
                table: "ClientOrders",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_ClientOrders_IdConfectionery",
                table: "Confectionery_ClientOrders",
                column: "IdConfectionery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_ClientOrders");

            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "Confectioneries");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
