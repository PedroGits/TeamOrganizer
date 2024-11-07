using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Application.Services.Interfaces;

namespace UserManager.Application.Features.User.Queries.Handlers
{
    public class ValidateUserQueryHandler : IRequestHandler<ValidateUserQuery, string?>
    {
        IUserService _userService;

        public ValidateUserQueryHandler(IUserService userService)
        {
            _userService = userService;    
        }

        public async Task<string?> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.ValidateUser(request.LoginDTO);
                
        }
    }
}
