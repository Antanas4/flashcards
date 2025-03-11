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

    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
        {
            try
            {
                var userDto = await _userService.GetUserByIdAsync(id);
                return Ok(userDto);
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

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdUserDto = await _userService.CreateUserAsync(userDto);
                return Ok(createdUserDto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{username}")]
        public async Task<ActionResult<UserDto>> UpdateUserByUsernameAsync(string username, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedUserDto = await _userService.UpdateUserByUsernameAsync(username, userDto);
                return Ok(updatedUserDto);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserByIdAsync(int id)
        {
            try
            {
                var result = await _userService.DeleteUserByIdAsync(id);
                if (result)
                {
                    return Ok(new { message = "User deleted successfully." });
                }
                return BadRequest("An error occurred while deleting the user.");
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