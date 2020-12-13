using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProductStore.Application.Commands.User;
using System.Threading.Tasks;

namespace MyProductStore.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            var user = await _mediator.Send(registerUserCommand);
            return Ok(user);
        }
    }
}
