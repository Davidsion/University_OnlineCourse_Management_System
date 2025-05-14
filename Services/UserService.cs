using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;
using BCrypt.Net;

namespace University_OnlineCourse_Management_System.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> CreateUserAsync(CreateUserDto createUserDto)
        {
            if (await _userRepository.GetByUsernameAsync(createUserDto.Username) != null ||
                await _userRepository.GetByEmailAsync(createUserDto.Email) != null)
            {
                return false; // Username or email already exists
            }

            var user = _mapper.Map<User>(createUserDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);
            await _userRepository.AddAsync(user);
            return await _userRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return false;
            }

            _mapper.Map(updateUserDto, existingUser);

            if (!string.IsNullOrEmpty(updateUserDto.Password))
            {
                existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUserDto.Password);
            }

            _userRepository.Update(existingUser);
            return await _userRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var userToDelete = await _userRepository.GetByIdAsync(id);
            if (userToDelete == null)
            {
                return false;
            }

            _userRepository.Delete(userToDelete);
            return await _userRepository.SaveChangesAsync();
        }
    }
}
