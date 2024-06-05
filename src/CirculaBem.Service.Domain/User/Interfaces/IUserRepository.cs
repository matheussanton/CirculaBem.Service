using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.User.Models;

namespace CirculaBem.Service.Domain.User.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(UserEntityDomain userEntity);
        Task<UserEntityDomain> GetByEmailAsync(string email);
        Task<SelectUserModel> GetByRegistrationNumberAsync(string registrationNumber);
    }
}
