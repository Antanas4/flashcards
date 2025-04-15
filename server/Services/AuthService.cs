using shared.Dtos;
using shared.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;



namespace server.Services
{
    public class AuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(AppDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDto> AuthenticateUserAsync(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user == null)
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetAuthenticatedUserAsync()
        {

            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.Name);
            var userId = userDataClaim;

            if (userId == null)
                return null;

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(userId.Value));

            return user != null ? _mapper.Map<UserDto>(user) : null;
        }
    }
}