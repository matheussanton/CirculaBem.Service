using CirculaBem.Service.Domain.Rent.Interfaces;
using CirculaBem.Service.Domain.Rent.Models;
using CirculaBem.Service.Domain.Rent.Queries.Requests;
using MediatR;

namespace CirculaBem.Service.Domain.Rent.Queries
{
    public class RentQueryHandler : IRequestHandler<GetRentsByProductRequest, List<SelectRent>>
    {
        private readonly IRentRepository _rentRepository;

        public RentQueryHandler(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task<List<SelectRent>> Handle(GetRentsByProductRequest request, CancellationToken cancellationToken)
        {
            return await _rentRepository.SelectRentsByProductAsync(request.ProductId, request.StartDate, request.EndDate);
        }
    }
}
