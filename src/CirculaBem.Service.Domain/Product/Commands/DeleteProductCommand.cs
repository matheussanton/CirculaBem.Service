using CirculaBem.Service.Domain.Bases.Commands;

namespace CirculaBem.Service.Domain.Product.Commands
{
    public class DeleteProductCommand : BaseDeleteCommand
    {
        public DeleteProductCommand(Guid id) : base(id) { }
    }
}
