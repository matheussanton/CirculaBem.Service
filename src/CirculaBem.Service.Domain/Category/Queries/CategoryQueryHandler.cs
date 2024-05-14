using CirculaBem.Service.Domain.Category.Interfaces;
using CirculaBem.Service.Domain.Category.Models;
using CirculaBem.Service.Domain.Category.Queries.Requests;
using MediatR;

namespace CirculaBem.Service.Domain.Category.Queries
{
    public class CategoryQueryHandler : IRequestHandler<GetCategoriesRequest, List<SelectCategory>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<List<SelectCategory>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoriesAsync();
        }
    }
}
