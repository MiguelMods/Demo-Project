using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.proyect_persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingGenderToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "dbo",
                table: "empleado",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "dbo",
                table: "empleado");
        }
    }
}
