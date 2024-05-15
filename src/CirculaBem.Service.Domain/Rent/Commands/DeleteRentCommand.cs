using CirculaBem.Service.Domain.Bases.Commands;

namespace CirculaBem.Service.Domain.Rent.Commands
{
    public class DeleteRentCommand : BaseDeleteCommand
    {
        public DeleteRentCommand(Guid id) : base(id) { }
    }
}
