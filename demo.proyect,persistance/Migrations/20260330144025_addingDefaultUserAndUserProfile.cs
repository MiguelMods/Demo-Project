using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingDefaultUserAndUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios",
                columns: new[] { "UserId", "CreatedBy", "Password", "UpdatedBy", "UserName" },
                values: new object[] { 1L, "system", "@dministrator", null, "administrator" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "usuarios_perfiles",
                columns: new[] { "ProfileId", "UserId", "CreatedBy", "UpdatedBy" },
                values: new object[] { 1L, 1L, "system", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios_perfiles",
                keyColumns: new[] { "ProfileId", "UserId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "usuarios",
                keyColumn: "UserId",
                keyValue: 1L);
        }
    }
}
