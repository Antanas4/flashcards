using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class CreateFlashcardListUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlashcardsCollectionId",
                table: "Flashcards",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlashcardsCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashcardsCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlashcardsCollection_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_FlashcardsCollectionId",
                table: "Flashcards",
                column: "FlashcardsCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardsCollection_UserId",
                table: "FlashcardsCollection",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flashcards_FlashcardsCollection_FlashcardsCollectionId",
                table: "Flashcards",
                column: "FlashcardsCollectionId",
                principalTable: "FlashcardsCollection",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashcards_FlashcardsCollection_FlashcardsCollectionId",
                table: "Flashcards");

            migrationBuilder.DropTable(
                name: "FlashcardsCollection");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Flashcards_FlashcardsCollectionId",
                table: "Flashcards");

            migrationBuilder.DropColumn(
                name: "FlashcardsCollectionId",
                table: "Flashcards");
        }
    }
}
