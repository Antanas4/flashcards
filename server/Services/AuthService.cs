using shared.Dtos;
using shared.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace server.Services
{
    public class AuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

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
    }
}