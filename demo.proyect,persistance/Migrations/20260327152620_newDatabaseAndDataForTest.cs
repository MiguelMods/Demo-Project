using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class newDatabaseAndDataForTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "perfiles",
                schema: "dbo",
                columns: table => new
                {
                    ProfileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    RowGuid = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfiles", x => x.ProfileId);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "perfiles",
                columns: new[] { "ProfileId", "CreatedBy", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "Me", "Administrador del sistema", "Administrador", null },
                    { 2L, "Me", "Default del sistema", "Default", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_perfiles_Name",
                schema: "dbo",
                table: "perfiles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_perfiles_RowGuid",
                schema: "dbo",
                table: "perfiles",
                column: "RowGuid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfiles",
                schema: "dbo");
        }
    }
}
