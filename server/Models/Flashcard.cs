using System.ComponentModel.DataAnnotations;


namespace server.Models
{
    public class Flashcard
    {
        [Key]
        public int Id {get; set;}
        public string Question {get; set;}
        public string Answer {get; set;}

        public Flashcard() {}

        // public Flashcard(string question, string answer)
        // {
        //     Question = question;
        //     Answer = answer;
        // }
    }
}