using CognitoDemo.Domain.Common;
using CognitoDemo.Domain.Enums;

namespace CognitoDemo.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public UserRole Role { get; set; }
        public required string PasswordHash { get; set; }
        public bool IsActive { get; set; } = true;
    }
}