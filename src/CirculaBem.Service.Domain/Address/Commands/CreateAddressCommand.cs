using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Address.Commands
{
    public class CreateAddressCommand : BaseAddressCommand
    {

        public AddressEntityDomain ParseToEntity()
        {
            return new AddressEntityDomain(
                UserRegistrationNumber,
                Cep,
                State,
                City,
                Neighborhood,
                Street,
                Number,
                Complement
            );
        }
    }
}
