using System.Collections.Generic;

namespace server.Dtos
{
    public class FlashcardsCollectionDto
    {
        public required int Id { get; set; }
        public required int OwnerId { get; set; }
        public required string Name { get; set; }
        public required List<FlashcardDto> Flashcards { get; set; }
        public required string Description { get; set; }
    }
}
