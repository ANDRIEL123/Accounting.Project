using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting.Project.Migrations
{
    /// <inheritdoc />
    public partial class update200620241939 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "operation",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "operation",
                table: "Notes");
        }
    }
}
