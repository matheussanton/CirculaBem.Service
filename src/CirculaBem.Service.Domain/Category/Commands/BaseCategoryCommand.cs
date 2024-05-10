using CirculaBem.Service.Domain.Entities;
using MediatR;

namespace CirculaBem.Service.Domain.Category.Commands
{
    public abstract class BaseCategoryCommand : IRequest
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public abstract CategoryEntityDomain Parse();
    }
}
