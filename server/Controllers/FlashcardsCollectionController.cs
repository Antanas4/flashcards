using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using server.Services;
using shared.Models;
using shared.Dtos;
using AutoMapper;

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
        public async Task<ActionResult<List<FlashcardsCollectionDto>>> GetFlashcardsCollectionsAsync()
        {
            try
            {
                var flashcardsCollections = await _flashcardsCollectionService.GetFlashcardsCollectionsAsync();
                return Ok(flashcardsCollections);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
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
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
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
    }
}