using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddStudySession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudySessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mode = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudySessionFlashcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlashcardId = table.Column<int>(type: "integer", nullable: false),
                    CorrectStreak = table.Column<int>(type: "integer", nullable: false),
                    FlashcardsCollectionId = table.Column<int>(type: "integer", nullable: false),
                    LastAnswerCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    TimesSeen = table.Column<int>(type: "integer", nullable: false),
                    StudySessionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySessionFlashcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudySessionFlashcards_FlashcardsCollection_FlashcardsColle~",
                        column: x => x.FlashcardsCollectionId,
                        principalTable: "FlashcardsCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudySessionFlashcards_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudySessionFlashcards_StudySessions_StudySessionId",
                        column: x => x.StudySessionId,
                        principalTable: "StudySessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudySessionFlashcards_FlashcardId",
                table: "StudySessionFlashcards",
                column: "FlashcardId");

            migrationBuilder.CreateIndex(
                name: "IX_StudySessionFlashcards_FlashcardsCollectionId",
                table: "StudySessionFlashcards",
                column: "FlashcardsCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudySessionFlashcards_StudySessionId",
                table: "StudySessionFlashcards",
                column: "StudySessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudySessionFlashcards");

            migrationBuilder.DropTable(
                name: "StudySessions");
        }
    }
}
