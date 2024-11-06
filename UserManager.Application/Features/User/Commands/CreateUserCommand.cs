using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Application.DTOs;
using UserManager.Domain.Entities;
using UserManager.Domain.Enums;

namespace UserManager.Application.Features.User.Commands
{
    public record CreateUserCommand : IRequest<Guid>
    {
        public UserDTO User { get; set; }

        public CreateUserCommand(UserDTO user)
        {
            User = user;
        }
    }
}
