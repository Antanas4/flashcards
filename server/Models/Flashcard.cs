using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Flashcard
    {
        [Key]
        public required int Id {get; set;}
        public required string Question {get; set;}
        public required string Answer {get; set;}

        public Flashcard() {}
    }
}