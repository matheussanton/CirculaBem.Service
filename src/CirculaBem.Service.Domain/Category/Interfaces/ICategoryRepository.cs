using CirculaBem.Service.Domain.Category.Models;
using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Category.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateAsync(CategoryEntityDomain category);
        Task UpdateAsync(CategoryEntityDomain category);
        Task DeleteAsync(Guid id);

        Task<List<SelectCategory>> GetCategoriesAsync();
    }
}
