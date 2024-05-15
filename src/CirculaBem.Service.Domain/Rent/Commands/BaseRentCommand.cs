using CirculaBem.Service.Domain.Entities;
using MediatR;

namespace CirculaBem.Service.Domain.Rent.Commands
{
    public abstract class BaseRentCommand : IRequest
    {
        public string UserRegistrationNumber { get; set; }
        public Guid ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public abstract RentEntityDomain Parse();
    }
}
