using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingNestSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewFieldsReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardingHouseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_BoardingHouses_BoardingHouseID",
                        column: x => x.BoardingHouseID,
                        principalTable: "BoardingHouses",
                        principalColumn: "BoardingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BoardingHouseID",
                table: "Reservations",
                column: "BoardingHouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
