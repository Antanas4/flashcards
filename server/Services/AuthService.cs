using shared.Dtos;
using shared.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;


namespace server.Services
{
    public class AuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            var user = _httpContextAccessor.HttpContext?.User;
            var userIdClaim = user?.FindFirst(JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return null;

            var dbUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(userIdClaim.Value));

            return dbUser != null ? _mapper.Map<UserDto>(dbUser) : null;
        }
    }
}