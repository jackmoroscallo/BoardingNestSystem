using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingNestSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BedNum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedID);
                });

            migrationBuilder.CreateTable(
                name: "BoardingHouses",
                columns: table => new
                {
                    BoardingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasActiveReservation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingHouses", x => x.BoardingID);
                    table.ForeignKey(
                        name: "FK_BoardingHouses_Beds_BedID",
                        column: x => x.BedID,
                        principalTable: "Beds",
                        principalColumn: "BedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardingHouses_BedID",
                table: "BoardingHouses",
                column: "BedID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardingHouses");

            migrationBuilder.DropTable(
                name: "Beds");
        }
    }
}
