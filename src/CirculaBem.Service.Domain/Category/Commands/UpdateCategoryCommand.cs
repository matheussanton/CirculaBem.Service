using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Category.Commands
{
    public class UpdateCategoryCommand : BaseCategoryCommand
    {
        public Guid Id { get; set; }
        public override CategoryEntityDomain Parse()
        => new CategoryEntityDomain(
            Description,
            ImageUrl,
            Id
        );
    }
}
