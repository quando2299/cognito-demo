using CognitoDemo.Domain.Enums;

namespace CognitoDemo.Application.DTOs.Auth
{
    public class AuthDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public int RefreshTokenExpiryTime { get; set; }
        public required string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
