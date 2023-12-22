using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updmgr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "RentACars");

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_PickUpLocationId",
                table: "RentACars",
                column: "PickUpLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationId",
                table: "RentACars",
                column: "PickUpLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_PickUpLocationId",
                table: "RentACars");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_PickUpLocationId",
                table: "RentACars");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "RentACars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
