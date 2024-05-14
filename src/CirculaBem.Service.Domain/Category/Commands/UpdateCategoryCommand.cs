using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Category.Commands
{
    public class UpdateCategoryCommand : BaseCategoryCommand
    {
        public Guid Id { get; private set; }
        public void SetId(Guid id) => Id = id;
        public override CategoryEntityDomain Parse()
        => new CategoryEntityDomain(
            Description,
            ImageUrl,
            Id
        );
    }
}
