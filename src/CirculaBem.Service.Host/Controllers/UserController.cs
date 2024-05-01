using CirculaBem.Service.Domain.Responses.Enums;
using CirculaBem.Service.Domain.User.Commands;
using CirculaBem.Service.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CirculaBem.Service.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserCommand command,
                                                   [FromServices] Response response
                                                )
        {
            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
            {
                return StatusCode((int)response.StatusCode, response.Notifications);
            }

            return Ok(response.Notifications);
        }

        // [HttpPatch("verify")]
        // public async Task<IActionResult> GetAsync()
        // {
        //     var users = await _userRepository.GetAllAsync();

        //     return Ok(users);
        // }
    }
}
