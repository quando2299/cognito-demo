using CognitoDemo.Domain.Enums;

namespace CognitoDemo.Application.DTOs.Auth
{
    public class UserRegisterRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required UserRole Role { get; set; }
    }
}
