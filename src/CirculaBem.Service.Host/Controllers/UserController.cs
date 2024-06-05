using CirculaBem.Service.Domain.Responses.Enums;
using CirculaBem.Service.Domain.User.Commands;
using CirculaBem.Service.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CirculaBem.Service.Domain.User.Queries.Requests;

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

        [HttpGet("{registrationNumber}")]
        public async Task<IActionResult> GetByRegistrationNumberAsync(string registrationNumber)
        {
            var response = await _mediator.Send(new GetUserByRegistrationNumberRequest() { RegistrationNumber = registrationNumber });

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
