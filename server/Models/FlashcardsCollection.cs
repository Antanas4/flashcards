using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class FlashcardsCollection
    {
        private int _id;
        private string _name;
        private string _description;
        private User _user;
        private List<Flashcard>? _flashcards;

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public User User
        {
            get => _user;
            set => _user = value;
        }

        public required string Name
        {
            get => _name;
            set => _name = value;
        }

        public List<Flashcard>? Flashcards
        {
            get => _flashcards;
            set => _flashcards = value;
        }

        public required string Description
        {
            get => _description;
            set => _description = value;
        }

        public FlashcardsCollection() { }
        
        public FlashcardsCollection(int id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
            _flashcards = new List<Flashcard>();
        }
    }
}
