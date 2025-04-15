using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using server.Services;
using shared.Models;
using shared.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsCollectionController : ControllerBase
    {
        private readonly FlashcardsCollectionService _flashcardsCollectionService;

        public FlashcardsCollectionController(FlashcardsCollectionService flashcardsCollectionService)
        {
            _flashcardsCollectionService = flashcardsCollectionService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<FlashcardsCollectionDto>>> GetMyFlashcardsCollectionsAsync()
        {
            try
            {
                var userCollections = await _flashcardsCollectionService.GetMyFlashcardsCollectionsAsync();
                return Ok(userCollections);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<FlashcardsCollectionDto>> CreateFlashcardsCollectionAsync([FromBody] FlashcardsCollectionDto collectionDto)
        {
            if (collectionDto == null)
            {
                return BadRequest("Flashcards collection data is required.");
            }
            try
            {
                var createdCollection = await _flashcardsCollectionService.CreateFlashcardsCollectionAsync(collectionDto);
                return Ok(createdCollection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlashcardsCollectionDto>> GetFlashcardsCollectionByIdAsync(int id)
        {
            try
            {
                var collectionDto = await _flashcardsCollectionService.GetFlashcardsCollectionByIdAsync(id);
                return Ok(collectionDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlashcardsCollectionByIdAsync(int id)
        {
            try
            {
                var result = await _flashcardsCollectionService.DeleteFlashcardsCollectionByIdAsync(id);
                if (result)
                {
                    return Ok(new { message = "Collection deleted successfully." });
                }
                return BadRequest("An error occurred while deleting the collection.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateFlashcardsCollectionByIdAsync(FlashcardsCollectionDto updatedCollectionDto)
        {
            try
            {
                var result = await _flashcardsCollectionService.UpdateFlashcardsCollectionByIdAsync(updatedCollectionDto);
                if (result)
                {
                    return Ok(new { message = "Collection updated successfully." });
                }
                return BadRequest("An error occurred while updating the collection.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}