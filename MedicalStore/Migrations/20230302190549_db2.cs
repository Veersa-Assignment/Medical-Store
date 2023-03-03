using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalStore.Migrations
{
    /// <inheritdoc />
    public partial class db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockIn = table.Column<int>(type: "int", nullable: false),
                    StockOut = table.Column<int>(type: "int", nullable: false),
                    Expired = table.Column<int>(type: "int", nullable: false),
                    Final = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pendings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockIn = table.Column<int>(type: "int", nullable: false),
                    StockOut = table.Column<int>(type: "int", nullable: false),
                    Expired = table.Column<int>(type: "int", nullable: false),
                    Final = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StoreKeepers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTiem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreKeepers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "StoreManagers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTiem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreManagers", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Pendings");

            migrationBuilder.DropTable(
                name: "StoreKeepers");

            migrationBuilder.DropTable(
                name: "StoreManagers");
        }
    }
}
