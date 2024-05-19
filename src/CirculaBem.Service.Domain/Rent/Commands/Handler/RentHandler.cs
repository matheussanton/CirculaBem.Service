using System.Net;
using CirculaBem.Service.Domain.Rent.Interfaces;
using CirculaBem.Service.Domain.Responses;
using CirculaBem.Service.Domain.Responses.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CirculaBem.Service.Domain.Rent.Commands.Handler
{
    public class RentHandler : IRequestHandler<CreateRentCommand>,
                               IRequestHandler<UpdateRentCommand>,
                               IRequestHandler<DeleteRentCommand>
    {
        private readonly IRentRepository _rentRepository;
        private readonly Response _response;
        private readonly IConfiguration _configuration;

        public RentHandler(IRentRepository rentRepository, Response response, IConfiguration configuration)
        {
            _rentRepository = rentRepository;
            _response = response;
            _configuration = configuration;
        }


        public async Task Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Parse();

            await _rentRepository.CreateAsync(entity);

            _response.Send(ResponseStatus.Success, HttpStatusCode.OK);
        }

        public async Task Handle(UpdateRentCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Parse();

            await _rentRepository.UpdateAsync(entity);

            _response.Send(ResponseStatus.Success, HttpStatusCode.OK);
        }

        public async Task Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            await _rentRepository.DeleteAsync(request.Id);

            _response.Send(ResponseStatus.Success, HttpStatusCode.OK);
        }
    }
}
