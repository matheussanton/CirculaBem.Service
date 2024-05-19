using CirculaBem.Service.Domain.Rent.Models;
using MediatR;

namespace CirculaBem.Service.Domain.Rent.Queries.Requests
{
    public class GetRentsByUserRequest : IRequest<List<SelectRent>>
    {
        public string UserRegistrationNumber { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
