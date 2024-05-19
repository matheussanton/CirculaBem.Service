using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.Rent.Models;

namespace CirculaBem.Service.Domain.Rent.Interfaces
{
    public interface IRentRepository
    {
        Task CreateAsync(RentEntityDomain category);
        Task UpdateAsync(RentEntityDomain category);
        Task DeleteAsync(Guid id);

        Task<List<SelectRent>> SelectRentsByProductAsync(Guid productId, DateTime startDate, DateTime endDate);
        Task<List<SelectRent>> SelectRentsByUserAsync(Guid userId, DateTime startDate, DateTime endDate);
    }
}
