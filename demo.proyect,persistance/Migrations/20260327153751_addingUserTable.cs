using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AskForNewPassword = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsBloked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_usuarios", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RowGuid",
                schema: "dbo",
                table: "usuarios",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_UserName",
                schema: "dbo",
                table: "usuarios",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "dbo");
        }
    }
}
