using System.ComponentModel.DataAnnotations;

namespace shared.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 20 characters.")]
        public required string Password { get; set; }
    }
}