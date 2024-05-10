using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Category.Commands
{
    public class CreateCategoryCommand : BaseCategoryCommand
    {
        public override CategoryEntityDomain Parse()
        => new CategoryEntityDomain(
            Description,
            ImageUrl
        );
    }
}
