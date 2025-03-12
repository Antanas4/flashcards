using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shared.Dtos
{
    public class FlashcardsCollectionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Owner ID is required")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "Collection Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public List<FlashcardDto> Flashcards { get; set; }
    }
}
