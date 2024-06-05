using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Address.Commands
{
    public class UpdateAddressCommand : BaseAddressCommand
    {
        public Guid Id { get; private set; }
        public void SetId(Guid id) => Id = id;

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
                Complement,
                Id
            );
        }
    }
}
