using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingSuperiorAreaToAreaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SuperiorAreaId",
                schema: "dbo",
                table: "areas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_areas_SuperiorAreaId",
                schema: "dbo",
                table: "areas",
                column: "SuperiorAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_areas_areas_SuperiorAreaId",
                schema: "dbo",
                table: "areas",
                column: "SuperiorAreaId",
                principalSchema: "dbo",
                principalTable: "areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_areas_areas_SuperiorAreaId",
                schema: "dbo",
                table: "areas");

            migrationBuilder.DropIndex(
                name: "IX_areas_SuperiorAreaId",
                schema: "dbo",
                table: "areas");

            migrationBuilder.DropColumn(
                name: "SuperiorAreaId",
                schema: "dbo",
                table: "areas");
        }
    }
}
