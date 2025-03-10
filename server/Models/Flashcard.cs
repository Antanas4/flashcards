using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Flashcard
    {
        private int _id;
        private string _question;
        private string _answer;

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Question
        {
            get => _question;
            set => _question = value;
        }

        public string Answer
        {
            get => _answer;
            set => _answer = value;
        }
    }
}
