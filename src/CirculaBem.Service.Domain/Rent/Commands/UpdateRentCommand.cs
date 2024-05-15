using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Rent.Commands
{
    public class UpdateRentCommand : BaseRentCommand
    {
        public Guid Id { get; private set; }
        public void SetId(Guid id) => Id = id;


        public override RentEntityDomain Parse()
        => new RentEntityDomain(
            UserRegistrationNumber,
            ProductId,
            StartDate,
            EndDate,
            Id
        );
    }
}
