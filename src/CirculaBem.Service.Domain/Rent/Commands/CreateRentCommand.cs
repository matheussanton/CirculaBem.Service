using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Rent.Commands
{
    public class CreateRentCommand : BaseRentCommand
    {
        public override RentEntityDomain Parse()
        => new RentEntityDomain
        {
            UserRegistrationNumber = UserRegistrationNumber,
            ProductId = ProductId,
            StartDate = StartDate,
            EndDate = EndDate
        };
    }
}
