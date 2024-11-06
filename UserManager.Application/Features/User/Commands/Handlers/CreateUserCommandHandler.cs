using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Application.Services.Interfaces;

namespace UserManager.Application.Features.User.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        public IUserService _userService { get; set; }
        public CreateUserCommandHandler(IUserService userService)
        {
                _userService = userService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUser(request.User);
        }
    }
}
