using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingDefaultAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "areas",
                columns: new[] { "AreaId", "Code", "CreatedBy", "Description", "Name", "SuperiorAreaId", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "01", "Me", "Prueba", "Prueba", null, null },
                    { 2L, "02", "Me", "Prueba 02", "Prueba 02", 1L, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "areas",
                keyColumn: "AreaId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "areas",
                keyColumn: "AreaId",
                keyValue: 1L);
        }
    }
}
