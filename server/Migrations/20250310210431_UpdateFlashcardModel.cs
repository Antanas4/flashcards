using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlashcardModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_FlashcardsCollection_FlashcardsCollectionId",
                table: "Flashcards");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "FlashcardsCollection",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FlashcardsCollectionId",
                table: "Flashcards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "Flashcards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_FlashcardsCollection_FlashcardsCollectionId",
                table: "Flashcards",
                column: "FlashcardsCollectionId",
                principalTable: "FlashcardsCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_FlashcardsCollection_FlashcardsCollectionId",
                table: "Flashcards");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "FlashcardsCollection");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Flashcards");

            migrationBuilder.AlterColumn<int>(
                name: "FlashcardsCollectionId",
                table: "Flashcards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_FlashcardsCollection_FlashcardsCollectionId",
                table: "Flashcards",
                column: "FlashcardsCollectionId",
                principalTable: "FlashcardsCollection",
                principalColumn: "Id");
        }
    }
}
