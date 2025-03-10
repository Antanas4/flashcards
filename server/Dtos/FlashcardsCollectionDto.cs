using System.Collections.Generic;

namespace server.Dtos
{
    public class FlashcardsCollectionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<FlashcardDto> Flashcards { get; set; }
        public string Description { get; set; }
    }
}
