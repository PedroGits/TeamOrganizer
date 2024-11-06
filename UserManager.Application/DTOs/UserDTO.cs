using UserManager.Domain.Entities;
using UserManager.Domain.Enums;

namespace UserManager.Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; private set; }
        public string? FullName { get; private set; }
        public string? Email { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }

        public UserDTO ToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                IsActive = user.IsActive
            };
        }

        public User ToNewEntity()
        {
            return new User(Id, FullName, Email, Role);
        }
    }
}
