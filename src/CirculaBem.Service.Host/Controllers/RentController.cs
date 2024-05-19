using System.ComponentModel.DataAnnotations;
using CirculaBem.Service.Domain.Rent.Commands;
using CirculaBem.Service.Domain.Rent.Queries.Requests;
using CirculaBem.Service.Domain.Responses;
using CirculaBem.Service.Domain.Responses.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CirculaBem.Service.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRentAsync([FromBody][Required] CreateRentCommand command,
                                                         [FromServices] Response response)
        {
            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
                return StatusCode((int)response.StatusCode, response.Notifications);

            return Ok(response.Notifications);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRentAsync([FromRoute][Required] Guid id,
                                                            [FromBody][Required] UpdateRentCommand command,
                                                            [FromServices] Response response)
        {
            command.SetId(id);

            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
                return StatusCode((int)response.StatusCode, response.Notifications);

            return Ok(response.Notifications);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentAsync(Guid id,
                                                         [FromServices] Response response)
        {
            var command = new DeleteRentCommand(id);

            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
            {
                return StatusCode((int)response.StatusCode, response.Notifications);
            }

            return Ok(response.Notifications);
        }

        [HttpGet("by-preoduct/{productId}")]
        public async Task<IActionResult> GetRentsByProductIdAsync(
            [FromRoute][Required] Guid productId,
            [FromQuery][Required] DateTime startDate,
            [FromQuery][Required] DateTime endDate)
        {
            var result = await _mediator.Send(new GetRentsByProductRequest
            {
                ProductId = productId,
                StartDate = startDate,
                EndDate = endDate
            });

            return Ok(result);
        }

        [HttpGet("by-user/{userRegistrationNumber}")]
        public async Task<IActionResult> GetRentsByUserAsync(
            [FromRoute][Required] string userRegistrationNumber,
            [FromQuery][Required] DateTime startDate,
            [FromQuery][Required] DateTime endDate)
        {
            var result = await _mediator.Send(new GetRentsByUserRequest
            {
                UserRegistrationNumber = userRegistrationNumber,
                StartDate = startDate,
                EndDate = endDate
            });

            return Ok(result);
        }
    }
}
