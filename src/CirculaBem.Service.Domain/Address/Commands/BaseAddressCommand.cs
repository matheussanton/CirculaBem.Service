using MediatR;

namespace CirculaBem.Service.Domain.Address.Commands
{
    public class BaseAddressCommand : IRequest
    {
        public string UserRegistrationNumber { get; set; }
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public short Number { get; set; }
        public string Complement { get; set; }
    }
}
