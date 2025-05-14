// DTO/LoginRequestDto.cs
using System.ComponentModel.DataAnnotations;

namespace University_OnlineCourse_Management_System.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        // You might include a token or user information upon successful login
        public bool IsAuthenticated { get; set; }
        public string? Message { get; set; }
        // Add other relevant user details or tokens here if needed
    }
}
