using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UserManager.Application.DTOs;
using UserManager.Application.Services.Interfaces;
using UserManager.Domain.Interfaces;

namespace UserManager.Application.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository; 
        }
        public async Task<Guid> CreateUser(UserDTO user)
        {
            return await _userRepository.AddAsync(user.ToNewEntity());

        }

        public Task<string?> ValidateUser(UserLoginDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
