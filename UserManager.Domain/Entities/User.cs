using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Enums;

namespace UserManager.Domain.Entities
{
    public class User:BaseEntity
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }
        
        public User(Guid id, string fullName, string email, string password, UserRole? role)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role ?? UserRole.User;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }
        public void Activate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateInfo(string fullName, string email, UserRole? role)
        {
            FullName = fullName;
            Email = email;
            Role = role ?? UserRole.User;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
