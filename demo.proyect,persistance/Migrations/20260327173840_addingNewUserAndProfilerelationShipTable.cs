using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingNewUserAndProfilerelationShipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios_perfiles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProfileId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_usuarios_perfiles", x => new { x.UserId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_usuarios_perfiles_perfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "dbo",
                        principalTable: "perfiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_perfiles_usuarios_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "usuarios",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_perfiles_ProfileId",
                schema: "dbo",
                table: "usuarios_perfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_perfiles_RowGuid",
                schema: "dbo",
                table: "usuarios_perfiles",
                column: "RowGuid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios_perfiles",
                schema: "dbo");
        }
    }
}
