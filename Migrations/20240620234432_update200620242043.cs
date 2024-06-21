using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting.Project.Migrations
{
    /// <inheritdoc />
    public partial class update200620242043 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accounts_match_account_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_assets_asset_id",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_people_person_id",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "notes");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_person_id",
                table: "notes",
                newName: "IX_notes_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_asset_id",
                table: "notes",
                newName: "IX_notes_asset_id");

            migrationBuilder.AlterColumn<long>(
                name: "match_account_id",
                table: "accounts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notes",
                table: "notes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accounts_match_account_id",
                table: "accounts",
                column: "match_account_id",
                principalTable: "accounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_assets_asset_id",
                table: "notes",
                column: "asset_id",
                principalTable: "assets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notes_people_person_id",
                table: "notes",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accounts_match_account_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_notes_assets_asset_id",
                table: "notes");

            migrationBuilder.DropForeignKey(
                name: "FK_notes_people_person_id",
                table: "notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notes",
                table: "notes");

            migrationBuilder.RenameTable(
                name: "notes",
                newName: "Notes");

            migrationBuilder.RenameIndex(
                name: "IX_notes_person_id",
                table: "Notes",
                newName: "IX_Notes_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_notes_asset_id",
                table: "Notes",
                newName: "IX_Notes_asset_id");

            migrationBuilder.AlterColumn<long>(
                name: "match_account_id",
                table: "accounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accounts_match_account_id",
                table: "accounts",
                column: "match_account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_assets_asset_id",
                table: "Notes",
                column: "asset_id",
                principalTable: "assets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_people_person_id",
                table: "Notes",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
