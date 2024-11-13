using SharedKernel.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Application.DTOs;

namespace UserManager.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ResultT<Guid>> CreateUser(UserDTO user);
        public Task<ResultT<string?>> ValidateUser(UserLoginDTO user);
    }
}
