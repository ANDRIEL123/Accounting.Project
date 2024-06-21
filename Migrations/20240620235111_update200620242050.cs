using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting.Project.Migrations
{
    /// <inheritdoc />
    public partial class update200620242050 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "assets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "assets");
        }
    }
}
