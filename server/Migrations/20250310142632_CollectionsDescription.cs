using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class CollectionsDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "FlashcardsCollection",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FlashcardsCollection",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FlashcardsCollection");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FlashcardsCollection",
                newName: "name");
        }
    }
}
