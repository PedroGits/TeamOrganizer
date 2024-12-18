﻿using MediatR;
using SharedKernel.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Application.DTOs;

namespace UserManager.Application.Features.User.Queries
{
    public class ValidateUserQuery:IRequest<Result<string?>>
    {
        public UserLoginDTO LoginDTO { get; set; }

        public ValidateUserQuery(UserLoginDTO loginDto)
        {
            LoginDTO = loginDto;
        }
    }
}
