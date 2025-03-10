using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class User
    {
        [Key]
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public List<FlashcardsCollection> FlashcardsCollection { get; set; }
    }
}