using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.Product.Models;

namespace CirculaBem.Service.Domain.Product.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(ProductEntityDomain product);

        Task<List<SelectProduct>> GetAllByOwnerAsync(string ownerRegistrationNumber);
    }
}
