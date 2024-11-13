using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UserManager.Application.DTOs;
using UserManager.Application.Features.User.Commands;
using UserManager.Application.Features.User.Queries;

namespace UserManager.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<UserDTO> _validator;
        public UserController(IMediator mediator, IValidator<UserDTO> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("validate")]
        public async Task<IActionResult> ValidateUser(string email, string password)
        {
            var role = await _mediator.Send(new ValidateUserQuery(new UserLoginDTO(email, password)));

            if (role is null)
                return Unauthorized();

            return Ok(new { Role = role });

        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(UserDTO userDto)
        {
            var validationResult = await _validator.ValidateAsync(userDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var userId = await _mediator.Send(new CreateUserCommand(userDto));
                return Ok(new { userId });
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
