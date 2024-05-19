using CirculaBem.Service.Domain.Rent.Models;
using MediatR;

namespace CirculaBem.Service.Domain.Rent.Queries.Requests
{
    public class GetRentsByProductRequest : IRequest<List<SelectRent>>
    {
        public Guid ProductId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
