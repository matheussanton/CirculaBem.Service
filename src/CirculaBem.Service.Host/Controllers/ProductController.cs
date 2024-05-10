using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CirculaBem.Service.Domain.Product.Commands;
using CirculaBem.Service.Domain.Product.Queries.Requests;
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
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody][Required] CreateProductCommand command,
                                                            [FromServices] Response response)
        {
            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
                return StatusCode((int)response.StatusCode, response.Notifications);

            return Ok(response.Notifications);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute][Required] Guid id,
                                                            [FromBody][Required] UpdateProductCommand command,
                                                            [FromServices] Response response)
        {
            command.SetId(id);

            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
                return StatusCode((int)response.StatusCode, response.Notifications);

            return Ok(response.Notifications);
        }

        [HttpGet("by-user")]
        public async Task<IActionResult> GetProductAsync([FromQuery][Required] string userRegistrationNumber)
        {
            var request = new GetUserProductsRequest()
            {
                UserRegistrationNumber = userRegistrationNumber
            };

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] UpdateProductCommand command)
        // {
        //     command.Id = id;
        //     var result = await _mediator.Send(command);

        //     if (result.Status == ResponseStatus.Fail)
        //     {
        //         return StatusCode((int)result.StatusCode, result.Notifications);
        //     }

        //     return Ok(result.Notifications);
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(Guid id,
                                                            [FromServices] Response response)
        {
            var command = new DeleteProductCommand(id);

            await _mediator.Send(command);

            if (response.Status == ResponseStatus.Fail)
            {
                return StatusCode((int)response.StatusCode, response.Notifications);
            }

            return Ok(response.Notifications);
        }
    }

}
