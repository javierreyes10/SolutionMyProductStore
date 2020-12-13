using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProductStore.Application.Commands.User;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Application.Queries.User;
using MyProductStore.Core.QueryParameter;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserOutputDto>>> GetAllUsers([FromQuery] UserQueryParameter parameters)
        {
            var products = await _mediator.Send(new GetAllUsersQuery(parameters));

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.Metadata));
            return Ok(products.Items);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            var user = await _mediator.Send(registerUserCommand);
            return Ok(user);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserCommand authenticateUserCommand)
        {
            var user = await _mediator.Send(authenticateUserCommand);
            return Ok(user);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordUserCommand forgotPasswordUserCommand)
        {
            var message = await _mediator.Send(forgotPasswordUserCommand);
            return Ok(new { message });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordUserCommand resetPasswordUserCommand)
        {
            var message = await _mediator.Send(resetPasswordUserCommand);
            return Ok(new { message });
        }
    }
}
