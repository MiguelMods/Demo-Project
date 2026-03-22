using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class demoTestInit : Migration
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
                name: "periodo",
                schema: "dbo",
                columns: table => new
                {
                    PeriodId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_periodo", x => x.PeriodId);
                });

            migrationBuilder.CreateTable(
                name: "perspectiva",
                schema: "dbo",
                columns: table => new
                {
                    PerspectiveId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_perspectiva", x => x.PerspectiveId);
                });

            migrationBuilder.CreateTable(
                name: "prj_tipo_ejecucion",
                schema: "dbo",
                columns: table => new
                {
                    ProjectDevelopmentTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "prj_tipo_prioridad",
                schema: "dbo",
                columns: table => new
                {
                    PriorityTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "prj_tipo_proyecto",
                schema: "dbo",
                columns: table => new
                {
                    ProjectTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "tipo_objetivo",
                schema: "dbo",
                columns: table => new
                {
                    GoalTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_tipo_objetivo", x => x.GoalTypeId);
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
                    PriorityTypeId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_prj_proyecto_prj_tipo_ejecucion_ProjectDevelopmentTypeId",
                        column: x => x.ProjectDevelopmentTypeId,
                        principalSchema: "dbo",
                        principalTable: "prj_tipo_ejecucion",
                        principalColumn: "ProjectDevelopmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prj_proyecto_prj_tipo_prioridad_PriorityTypeId",
                        column: x => x.PriorityTypeId,
                        principalSchema: "dbo",
                        principalTable: "prj_tipo_prioridad",
                        principalColumn: "PriorityTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prj_proyecto_prj_tipo_proyecto_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalSchema: "dbo",
                        principalTable: "prj_tipo_proyecto",
                        principalColumn: "ProjectTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "objetivos",
                schema: "dbo",
                columns: table => new
                {
                    GoalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsReal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    PeriodId = table.Column<long>(type: "bigint", nullable: false),
                    PerspectiveId = table.Column<long>(type: "bigint", nullable: false),
                    GoalTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectEntityProjectId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_objetivos", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_objetivos_areas_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "dbo",
                        principalTable: "areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objetivos_periodo_PeriodId",
                        column: x => x.PeriodId,
                        principalSchema: "dbo",
                        principalTable: "periodo",
                        principalColumn: "PeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objetivos_perspectiva_PerspectiveId",
                        column: x => x.PerspectiveId,
                        principalSchema: "dbo",
                        principalTable: "perspectiva",
                        principalColumn: "PerspectiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objetivos_prj_proyecto_ProjectEntityProjectId",
                        column: x => x.ProjectEntityProjectId,
                        principalSchema: "dbo",
                        principalTable: "prj_proyecto",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_objetivos_prj_proyecto_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "dbo",
                        principalTable: "prj_proyecto",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objetivos_tipo_objetivo_GoalTypeId",
                        column: x => x.GoalTypeId,
                        principalSchema: "dbo",
                        principalTable: "tipo_objetivo",
                        principalColumn: "GoalTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "iniciativa",
                schema: "dbo",
                columns: table => new
                {
                    InitiativeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ActionPlanOriginId = table.Column<long>(type: "bigint", nullable: true),
                    IsReal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsExecutable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    GoalId = table.Column<long>(type: "bigint", nullable: false),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    GoalEntityGoalId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_iniciativa", x => x.InitiativeId);
                    table.ForeignKey(
                        name: "FK_iniciativa_areas_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "dbo",
                        principalTable: "areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_iniciativa_objetivos_GoalEntityGoalId",
                        column: x => x.GoalEntityGoalId,
                        principalSchema: "dbo",
                        principalTable: "objetivos",
                        principalColumn: "GoalId");
                    table.ForeignKey(
                        name: "FK_iniciativa_objetivos_GoalId",
                        column: x => x.GoalId,
                        principalSchema: "dbo",
                        principalTable: "objetivos",
                        principalColumn: "GoalId");
                });

            migrationBuilder.CreateTable(
                name: "plan_accion",
                schema: "dbo",
                columns: table => new
                {
                    ActionPlanId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsExecutable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Converted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AreaId = table.Column<long>(type: "bigint", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    InitiativeId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_plan_accion", x => x.ActionPlanId);
                    table.ForeignKey(
                        name: "FK_plan_accion_areas_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "dbo",
                        principalTable: "areas",
                        principalColumn: "AreaId");
                    table.ForeignKey(
                        name: "FK_plan_accion_iniciativa_ActionPlanId",
                        column: x => x.ActionPlanId,
                        principalSchema: "dbo",
                        principalTable: "iniciativa",
                        principalColumn: "InitiativeId");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "prj_tipo_ejecucion",
                columns: new[] { "ProjectDevelopmentTypeId", "CreatedBy", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "me", "fast track", "fast track", null },
                    { 2L, "me", "super fast track", "super fast track", null },
                    { 3L, "me", "full track", "full track", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "prj_tipo_prioridad",
                columns: new[] { "PriorityTypeId", "CreatedBy", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "seed-on-proyect", "best effort", "best effort", null },
                    { 2L, "seed-on-proyect", "time sensitive", "time sensitive", null },
                    { 3L, "seed-on-proyect", "top priority", "top priority", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "prj_tipo_proyecto",
                columns: new[] { "ProjectTypeId", "CreatedBy", "Description", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "me", "Regulatorio", "Regulatorio", null },
                    { 2L, "me", "Comercial", "Comercial", null },
                    { 3L, "me", "Tecnico", "Tecnico", null }
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
                name: "IX_iniciativa_ActionPlanOriginId",
                schema: "dbo",
                table: "iniciativa",
                column: "ActionPlanOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_iniciativa_AreaId",
                schema: "dbo",
                table: "iniciativa",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_iniciativa_GoalEntityGoalId",
                schema: "dbo",
                table: "iniciativa",
                column: "GoalEntityGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_iniciativa_GoalId",
                schema: "dbo",
                table: "iniciativa",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_iniciativa_Name",
                schema: "dbo",
                table: "iniciativa",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iniciativa_RowGuid",
                schema: "dbo",
                table: "iniciativa",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_AreaId",
                schema: "dbo",
                table: "objetivos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_Code",
                schema: "dbo",
                table: "objetivos",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_GoalTypeId",
                schema: "dbo",
                table: "objetivos",
                column: "GoalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_PeriodId",
                schema: "dbo",
                table: "objetivos",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_PerspectiveId",
                schema: "dbo",
                table: "objetivos",
                column: "PerspectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_ProjectEntityProjectId",
                schema: "dbo",
                table: "objetivos",
                column: "ProjectEntityProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_ProjectId",
                schema: "dbo",
                table: "objetivos",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_objetivos_RowGuid",
                schema: "dbo",
                table: "objetivos",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_periodo_Name",
                schema: "dbo",
                table: "periodo",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_periodo_RowGuid",
                schema: "dbo",
                table: "periodo",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_perspectiva_Name",
                schema: "dbo",
                table: "perspectiva",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_perspectiva_RowGuid",
                schema: "dbo",
                table: "perspectiva",
                column: "RowGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plan_accion_AreaId",
                schema: "dbo",
                table: "plan_accion",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_plan_accion_Name",
                schema: "dbo",
                table: "plan_accion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plan_accion_RowGuid",
                schema: "dbo",
                table: "plan_accion",
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
                name: "IX_prj_proyecto_PriorityTypeId",
                schema: "dbo",
                table: "prj_proyecto",
                column: "PriorityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_prj_proyecto_ProjectDevelopmentTypeId",
                schema: "dbo",
                table: "prj_proyecto",
                column: "ProjectDevelopmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_prj_proyecto_ProjectTypeId",
                schema: "dbo",
                table: "prj_proyecto",
                column: "ProjectTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_tipo_objetivo_Name",
                schema: "dbo",
                table: "tipo_objetivo",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tipo_objetivo_RowGuid",
                schema: "dbo",
                table: "tipo_objetivo",
                column: "RowGuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_iniciativa_plan_accion_ActionPlanOriginId",
                schema: "dbo",
                table: "iniciativa",
                column: "ActionPlanOriginId",
                principalSchema: "dbo",
                principalTable: "plan_accion",
                principalColumn: "ActionPlanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_iniciativa_areas_AreaId",
                schema: "dbo",
                table: "iniciativa");

            migrationBuilder.DropForeignKey(
                name: "FK_objetivos_areas_AreaId",
                schema: "dbo",
                table: "objetivos");

            migrationBuilder.DropForeignKey(
                name: "FK_plan_accion_areas_AreaId",
                schema: "dbo",
                table: "plan_accion");

            migrationBuilder.DropForeignKey(
                name: "FK_prj_proyecto_areas_AreaId",
                schema: "dbo",
                table: "prj_proyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_prj_proyecto_areas_SubAreaId",
                schema: "dbo",
                table: "prj_proyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_iniciativa_objetivos_GoalEntityGoalId",
                schema: "dbo",
                table: "iniciativa");

            migrationBuilder.DropForeignKey(
                name: "FK_iniciativa_objetivos_GoalId",
                schema: "dbo",
                table: "iniciativa");

            migrationBuilder.DropForeignKey(
                name: "FK_iniciativa_plan_accion_ActionPlanOriginId",
                schema: "dbo",
                table: "iniciativa");

            migrationBuilder.DropTable(
                name: "areas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "objetivos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "periodo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "perspectiva",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "prj_proyecto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tipo_objetivo",
                schema: "dbo");

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
                name: "plan_accion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "iniciativa",
                schema: "dbo");
        }
    }
}
