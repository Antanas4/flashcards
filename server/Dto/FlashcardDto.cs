namespace server.Dto
{
    public class FlashcardDto
    {
        public required int Id { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
    }
}
