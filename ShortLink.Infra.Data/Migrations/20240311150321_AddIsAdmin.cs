using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortLink.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsbBot",
                table: "Devices",
                newName: "IsBot");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "IsBot",
                table: "Devices",
                newName: "IsbBot");
        }
    }
}
