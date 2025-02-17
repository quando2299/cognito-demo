using CognitoDemo.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CognitoDemo.API.DTOs.Auth
{
    public class UserRegisterRequest
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required UserRole Role { get; set; }
    }
}
