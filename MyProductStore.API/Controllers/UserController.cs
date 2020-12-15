using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProductStore.API.Filters;
using MyProductStore.Application.Commands.Users;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Application.Queries.User;
using MyProductStore.Core.QueryParameter;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProductStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseUserControllerController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieve a list of all the users registered. A "X-Pagination" Response Header is added for more details about pagination
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserOutputDto>>> GetAllUsers([FromQuery] UserQueryParameter parameters)
        {
            var products = await _mediator.Send(new GetAllUsersQuery(parameters));

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.Metadata));
            return Ok(products.Items);
        }

        /// <summary>
        /// Retrieve a specific user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}", Name = "GeUserById")]
        public async Task<ActionResult<UserOutputDto>> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user == null) return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Register a new user. A JWT token will be provided
        /// </summary>
        /// <param name="userInputDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserInputDto userInputDto)
        {
            var user = await _mediator.Send(new RegisterUserCommand(userInputDto));
            return Ok(user);
        }

        /// <summary>
        /// User authentication. A JWT token will be provided 
        /// </summary>
        /// <param name="authenticateUserCommand"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserCommand authenticateUserCommand)
        {
            var user = await _mediator.Send(authenticateUserCommand);
            return Ok(user);
        }

        /// <summary>
        /// Use this endpoint for request a password reset. You will receive an email with a reset token.
        /// </summary>
        /// <param name="forgotPasswordUserCommand"></param>
        /// <returns></returns>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordUserCommand forgotPasswordUserCommand)
        {
            var message = await _mediator.Send(forgotPasswordUserCommand);
            return Ok(new { message });
        }

        /// <summary>
        /// You must provide the token sent by the "forgot-password" endpoint for resetting your password.
        /// Token available for 15 minutes only
        /// </summary>
        /// <param name="resetPasswordUserCommand"></param>
        /// <returns></returns>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordUserCommand resetPasswordUserCommand)
        {
            var message = await _mediator.Send(resetPasswordUserCommand);
            return Ok(new { message });
        }

        /// <summary>
        /// Update a user by Id. An specific user can update his/her own information only
        /// </summary>
        /// <param name="id"></param>
        /// <param name="putUserInputDto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserInputDto putUserInputDto)
        {
            var user = await _mediator.Send(new PutUserCommand(id, putUserInputDto, UserId.Value));

            if (user == null) return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Delete a user by Id. An specific user can delete his/her own account only
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _mediator.Send(new DeleteUserCommand(id, UserId.Value));

            if (user == null) return NotFound();

            return NoContent();
        }
    }
}
