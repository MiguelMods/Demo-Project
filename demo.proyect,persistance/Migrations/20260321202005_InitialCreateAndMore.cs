using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "areas",
                schema: "dbo",
                columns: table => new
                {
                    AreaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "prj_proyecto",
                schema: "dbo",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeOne = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CodeTwo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Objetive = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Scope = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    SubAreaId = table.Column<long>(type: "bigint", nullable: false),
                    PoaRoadmap = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCritical = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UseNormalFlow = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PriorityId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectDevelopmentTypeId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_prj_proyecto", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_prj_proyecto_areas_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "dbo",
                        principalTable: "areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prj_proyecto_areas_SubAreaId",
                        column: x => x.SubAreaId,
                        principalSchema: "dbo",
                        principalTable: "areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "prj_tipo_ejecucion",
                schema: "dbo",
                columns: table => new
                {
                    ProjectDevelopmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_prj_tipo_ejecucion", x => x.ProjectDevelopmentTypeId);
                    table.ForeignKey(
                        name: "FK_prj_tipo_ejecucion_prj_proyecto_ProjectDevelopmentTypeId",
                        column: x => x.ProjectDevelopmentTypeId,
                        principalSchema: "dbo",
                        principalTable: "prj_proyecto",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prj_tipo_prioridad",
                schema: "dbo",
                columns: table => new
                {
                    PriorityTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_prj_tipo_prioridad", x => x.PriorityTypeId);
                    table.ForeignKey(
                        name: "FK_prj_tipo_prioridad_prj_proyecto_PriorityTypeId",
                        column: x => x.PriorityTypeId,
                        principalSchema: "dbo",
                        principalTable: "prj_proyecto",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prj_tipo_proyecto",
                schema: "dbo",
                columns: table => new
                {
                    ProjectTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_prj_tipo_proyecto", x => x.ProjectTypeId);
                    table.ForeignKey(
                        name: "FK_prj_tipo_proyecto_prj_proyecto_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalSchema: "dbo",
                        principalTable: "prj_proyecto",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_areas_Code",
                schema: "dbo",
                table: "areas",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_areas_Name",
                schema: "dbo",
                table: "areas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_areas_RowGuid",
                schema: "dbo",
                table: "areas",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_proyecto_AreaId",
                schema: "dbo",
                table: "prj_proyecto",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_prj_proyecto_CodeOne",
                schema: "dbo",
                table: "prj_proyecto",
                column: "CodeOne",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_proyecto_Name",
                schema: "dbo",
                table: "prj_proyecto",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_proyecto_RowGuid",
                schema: "dbo",
                table: "prj_proyecto",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_proyecto_SubAreaId",
                schema: "dbo",
                table: "prj_proyecto",
                column: "SubAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_prj_tipo_ejecucion_Name",
                schema: "dbo",
                table: "prj_tipo_ejecucion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_tipo_ejecucion_RowGuid",
                schema: "dbo",
                table: "prj_tipo_ejecucion",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_tipo_prioridad_Name",
                schema: "dbo",
                table: "prj_tipo_prioridad",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_tipo_prioridad_RowGuid",
                schema: "dbo",
                table: "prj_tipo_prioridad",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_tipo_proyecto_Name",
                schema: "dbo",
                table: "prj_tipo_proyecto",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prj_tipo_proyecto_RowGuid",
                schema: "dbo",
                table: "prj_tipo_proyecto",
                column: "RowGuid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prj_tipo_ejecucion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "prj_tipo_prioridad",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "prj_tipo_proyecto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "prj_proyecto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "areas",
                schema: "dbo");
        }
    }
}
