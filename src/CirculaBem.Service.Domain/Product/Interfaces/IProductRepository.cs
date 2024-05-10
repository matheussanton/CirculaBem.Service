using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.Product.Models;

namespace CirculaBem.Service.Domain.Product.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(ProductEntityDomain product);
        Task UpdateAsync(ProductEntityDomain product);
        Task DeleteAsync(Guid id);

        Task<List<SelectProduct>> GetAllByOwnerAsync(string ownerRegistrationNumber);
    }
}
