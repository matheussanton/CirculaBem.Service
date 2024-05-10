using MediatR;

namespace CirculaBem.Service.Domain.Bases.Commands
{
    public class BaseDeleteCommand : IRequest
    {
        public BaseDeleteCommand() { }
        public BaseDeleteCommand(Guid id) { Id = id; }

        public Guid Id { get; private set; }
        public void SetId(Guid id) => Id = id;

    }
}
