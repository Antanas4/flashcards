using System.ComponentModel.DataAnnotations;

namespace shared.Models
{
    public class User
    {
        private int _id;
        private string _username;
        private string _password;
        private List<FlashcardsCollection>? _flashcardsCollection;

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public required string Username
        {
            get => _username;
            set => _username = value;
        }

        public required string Password
        {
            get => _password;
            set => _password = value;
        }

        public List<FlashcardsCollection>? FlashcardsCollection
        {
            get => _flashcardsCollection;
            set => _flashcardsCollection = value;
        }

        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }
    }
}
