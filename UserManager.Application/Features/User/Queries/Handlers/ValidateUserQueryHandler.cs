using MediatR;
using SharedKernel.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Application.Services.Interfaces;

namespace UserManager.Application.Features.User.Queries.Handlers
{
    public class ValidateUserQueryHandler : IRequestHandler<ValidateUserQuery, Result<string?>>
    {
        IUserService _userService;

        public ValidateUserQueryHandler(IUserService userService)
        {
            _userService = userService;    
        }

        public async Task<Result<string?>> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
        {
            var isUserValid = await _userService.ValidateUser(request.LoginDTO);

            if (!isUserValid)
                return Result<string?>.Failure(Error.AccessUnAuthorized("LoginFailed", "Combination User/Password not found"));

            return Result<string?>.Success(isUserValid);
                
        }
    }
}
