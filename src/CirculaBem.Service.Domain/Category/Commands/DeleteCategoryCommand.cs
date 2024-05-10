using CirculaBem.Service.Domain.Bases.Commands;

namespace CirculaBem.Service.Domain.Category.Commands
{
    public class DeleteCategoryCommand : BaseDeleteCommand
    {
        public DeleteCategoryCommand(Guid id) : base(id) { }
    }
}
