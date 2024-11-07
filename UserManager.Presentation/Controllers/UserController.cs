using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManager.Application.DTOs;
using UserManager.Application.Features.User.Queries;

namespace UserManager.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("validate")]
        public async Task<IActionResult> ValidateUser(string email, string password)
        {
            var role = await _mediator.Send(new ValidateUserQuery(new UserLoginDTO(email, password)));

            if (role is null)
                return Unauthorized();

            return Ok(new { Role = role });

        }
    }
}
