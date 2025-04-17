using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using shared.Models;
using shared.Dtos;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TokenProvider _tokenProvider;
        private readonly AuthService _authService;

        public AuthController(IConfiguration configuration, TokenProvider tokenProvider, AuthService authService)
        {
            _configuration = configuration;
            _tokenProvider = tokenProvider;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto loginRequest)
        {
            var userDto = await _authService.AuthenticateUserAsync(loginRequest.Username, loginRequest.Password);
    
            if (userDto == null)
                return Unauthorized(new { message = "Invalid username or password." });

            string token = _tokenProvider.Create(userDto);
            return Ok(new { Token = token });
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAuthenticatedUserAsync()
        {
            var user = await _authService.GetAuthenticatedUserAsync();
            if (user == null)
                return NotFound("User not authenticated.");
            
            return Ok(user);
        }
    }
}