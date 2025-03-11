using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shared.Models;
using shared.Dtos;
using AutoMapper;

namespace server.Services
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id) ?? throw new KeyNotFoundException("User not found");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var existingUser = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username == userDto.Username);

            if (existingUser != null)
            {
                throw new InvalidOperationException("Username is already taken." + existingUser.Username);
            }

            var user = _mapper.Map<User>(userDto);
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserByUsernameAsync(string username, UserDto userDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            _mapper.Map(userDto, user);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}