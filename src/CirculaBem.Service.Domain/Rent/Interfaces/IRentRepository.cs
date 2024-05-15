using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Rent.Interfaces
{
    public interface IRentRepository
    {
        Task CreateAsync(RentEntityDomain category);
        Task UpdateAsync(RentEntityDomain category);
        Task DeleteAsync(Guid id);
    }
}
