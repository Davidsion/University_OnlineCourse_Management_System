// Services/AuthService.cs
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;
using BCrypt.Net;

namespace University_OnlineCourse_Management_System.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginRequestDto.Username);

            if (user == null)
            {
                return new LoginResponseDto { IsAuthenticated = false, Message = "Invalid username or password." };
            }

            if (!BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.PasswordHash))
            {
                return new LoginResponseDto { IsAuthenticated = false, Message = "Invalid username or password." };
            }

            return new LoginResponseDto { IsAuthenticated = true, Message = "Login successful." };
            // In a real application, you would typically generate and return a JWT or other authentication token here.
        }
    }
}