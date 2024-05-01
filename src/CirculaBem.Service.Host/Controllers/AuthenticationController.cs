using CirculaBem.Service.Domain.Authentication.Commands;
using CirculaBem.Service.Domain.Responses;
using CirculaBem.Service.Domain.Responses.Enums;
using CirculaBem.Service.Domain.User.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CirculaBem.Service.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Post([FromBody] AuthenticateRequest command,
                                            [FromServices] Response<UserDTO> response)
        {
            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
            {
                return StatusCode((int)response.StatusCode, response.Notifications);
            }

            return Ok(response.Value);
        }
    }
}
