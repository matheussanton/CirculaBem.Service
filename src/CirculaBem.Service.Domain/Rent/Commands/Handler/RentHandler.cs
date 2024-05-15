using CirculaBem.Service.Domain.Rent.Interfaces;
using CirculaBem.Service.Domain.Responses;
using MediatR;

namespace CirculaBem.Service.Domain.Rent.Commands.Handler
{
    public class RentHandler : IRequestHandler<CreateRentCommand>,
                               IRequestHandler<UpdateRentCommand>,
                               IRequestHandler<DeleteRentCommand>
    {
        private readonly IRentRepository _categoryRepository;
        private readonly Response _response;

        public RentHandler(IRentRepository categoryRepository, Response response)
        {
            _categoryRepository = categoryRepository;
            _response = response;
        }


        public async Task Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Handle(UpdateRentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
