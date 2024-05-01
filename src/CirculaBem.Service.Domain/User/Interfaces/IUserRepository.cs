using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.User.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(UserEntityDomain userEntity);
        Task<UserEntityDomain> GetByEmailAsync(string email);
    }
}
