using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Odontogest.Migrations
{
    public partial class Inventarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Category = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__CBD74706662D23AD", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    IdStore = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Store = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity_articles = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    New_Articles = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Store__2A8EB278F30AFE24", x => x.IdStore);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    IdInventory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Inventory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fk_Category = table.Column<int>(type: "int", nullable: true),
                    Fk_Store = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Quantity_Available = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    User_creation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    creation_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    User_Update = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date_Update = table.Column<DateTime>(type: "datetime", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventor__E6B6107B361D8002", x => x.IdInventory);
                    table.ForeignKey(
                        name: "Fk_Inventory_Category",
                        column: x => x.Fk_Category,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Inventory_store",
                        column: x => x.Fk_Store,
                        principalTable: "Store",
                        principalColumn: "IdStore",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Fk_Category",
                table: "Inventory",
                column: "Fk_Category");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Fk_Store",
                table: "Inventory",
                column: "Fk_Store");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
