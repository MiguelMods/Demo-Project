using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "periodo",
                columns: new[] { "PeriodId", "CreatedBy", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "Me", "Periodo de #1", "Periodo de #1", null },
                    { 2L, "Me", "Periodo de #2", "Periodo de #2", null },
                    { 3L, "Me", "Periodo de #3", "Periodo de #3", null },
                    { 4L, "Me", "Periodo de #4", "Periodo de #4", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "perspectiva",
                columns: new[] { "PerspectiveId", "CreatedBy", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "me", "Perspectiva #1", "Perspectiva #1", null },
                    { 2L, "me", "Perspectiva #2", "Perspectiva #2", null },
                    { 3L, "me", "Perspectiva #3", "Perspectiva #3", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tipo_objetivo",
                columns: new[] { "GoalTypeId", "CreatedBy", "Description", "Name", "UpdatedBy" },
                values: new object[] { 1L, "me", null, "Tipo objetivo 1", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "periodo",
                keyColumn: "PeriodId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "periodo",
                keyColumn: "PeriodId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "periodo",
                keyColumn: "PeriodId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "periodo",
                keyColumn: "PeriodId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "perspectiva",
                keyColumn: "PerspectiveId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "perspectiva",
                keyColumn: "PerspectiveId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "perspectiva",
                keyColumn: "PerspectiveId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "tipo_objetivo",
                keyColumn: "GoalTypeId",
                keyValue: 1L);
        }
    }
}
