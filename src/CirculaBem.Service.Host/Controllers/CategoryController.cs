using System.ComponentModel.DataAnnotations;
using CirculaBem.Service.Domain.Category.Commands;
using CirculaBem.Service.Domain.Category.Queries.Requests;
using CirculaBem.Service.Domain.Responses;
using CirculaBem.Service.Domain.Responses.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CirculaBem.Service.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody][Required] CreateCategoryCommand command,
                                                            [FromServices] Response response)
        {
            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
                return StatusCode((int)response.StatusCode, response.Notifications);

            return Ok(response.Notifications);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute][Required] Guid id,
                                                            [FromBody][Required] UpdateCategoryCommand command,
                                                            [FromServices] Response response)
        {
            command.SetId(id);

            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
                return StatusCode((int)response.StatusCode, response.Notifications);

            return Ok(response.Notifications);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryAsync()
        {
            var result = await _mediator.Send(new GetCategoriesRequest());

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id,
                                                            [FromServices] Response response)
        {
            var command = new DeleteCategoryCommand(id);

            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
            {
                return StatusCode((int)response.StatusCode, response.Notifications);
            }

            return Ok(response.Notifications);
        }
    }
}
