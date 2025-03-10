namespace server.Models
{
    public class FlashcardsCollection
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
        public User User { get; set; }
        public required string name { get; set; }
        public List<Flashcard> Flashcards { get; set; }
    }
}