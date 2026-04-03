using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class addindEmployeesPositionLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                schema: "dbo",
                table: "objetivos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "niveles",
                schema: "dbo",
                columns: table => new
                {
                    LevelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Superior = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Infection = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SuperiorLevelId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_niveles", x => x.LevelId);
                    table.ForeignKey(
                        name: "FK_niveles_niveles_SuperiorLevelId",
                        column: x => x.SuperiorLevelId,
                        principalSchema: "dbo",
                        principalTable: "niveles",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "posiciones",
                schema: "dbo",
                columns: table => new
                {
                    PositionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    LevelId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_posiciones", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_posiciones_niveles_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "dbo",
                        principalTable: "niveles",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "empleado",
                schema: "dbo",
                columns: table => new
                {
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FirtName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionId = table.Column<long>(type: "bigint", nullable: false),
                    SuperiorEmployeeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_empleado", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_empleado_areas_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "dbo",
                        principalTable: "areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_empleado_empleado_SuperiorEmployeeId",
                        column: x => x.SuperiorEmployeeId,
                        principalSchema: "dbo",
                        principalTable: "empleado",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_empleado_posiciones_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "dbo",
                        principalTable: "posiciones",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_EmployeeId",
                schema: "dbo",
                table: "objetivos",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_Code",
                schema: "dbo",
                table: "empleado",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_empleado_PositionId",
                schema: "dbo",
                table: "empleado",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_RowGuid",
                schema: "dbo",
                table: "empleado",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_empleado_SuperiorEmployeeId",
                schema: "dbo",
                table: "empleado",
                column: "SuperiorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_niveles_Name",
                schema: "dbo",
                table: "niveles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_niveles_RowGuid",
                schema: "dbo",
                table: "niveles",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_niveles_SuperiorLevelId",
                schema: "dbo",
                table: "niveles",
                column: "SuperiorLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_posiciones_LevelId",
                schema: "dbo",
                table: "posiciones",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_posiciones_Name",
                schema: "dbo",
                table: "posiciones",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_posiciones_RowGuid",
                schema: "dbo",
                table: "posiciones",
                column: "RowGuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_objetivos_empleado_EmployeeId",
                schema: "dbo",
                table: "objetivos",
                column: "EmployeeId",
                principalSchema: "dbo",
                principalTable: "empleado",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_objetivos_empleado_EmployeeId",
                schema: "dbo",
                table: "objetivos");

            migrationBuilder.DropTable(
                name: "empleado",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "posiciones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "niveles",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_objetivos_EmployeeId",
                schema: "dbo",
                table: "objetivos");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "objetivos");
        }
    }
}
