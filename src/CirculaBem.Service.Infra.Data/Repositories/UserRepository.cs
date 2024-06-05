using CirculaBem.Service.Domain.Address.Models;
using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.User.Extensions;
using CirculaBem.Service.Domain.User.Interfaces;
using CirculaBem.Service.Domain.User.Models;
using CirculaBem.Service.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CirculaBem.Service.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context { get; }
        private ILogger<UserRepository> _logger { get; }

        public UserRepository(AppDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateAsync(UserEntityDomain userEntity)
        {
            try
            {
                await _context.Users.AddAsync(userEntity);

                if (userEntity.Address != null)
                    await _context.Adresses.AddAsync(userEntity.Address);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR CREATING USER");
            }
        }

        public async Task<UserEntityDomain> GetByEmailAsync(string email)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR GETTING USER BY EMAIL");
                return null;
            }
        }

        public async Task<SelectUserModel> GetByRegistrationNumberAsync(string registrationNumber)
        {
            try
            {
                var obj =
                _context.Users
                .Select(u => new
                {
                    User = u,
                    Address = _context.Adresses
                        .Where(a => a.UserRegistrationNumber == u.RegistrationNumber)
                        .FirstOrDefault()
                })
                .Where(u => u.User.RegistrationNumber == registrationNumber)
                .FirstOrDefault();


                return new SelectUserModel
                {
                    RegistrationNumber = obj.User.RegistrationNumber,
                    Name = obj.User.GetFullName(),
                    Email = obj.User.Email,
                    Address = new SelectAddress
                    {
                        Cep = obj.Address.Cep,
                        State = obj.Address.State,
                        City = obj.Address.City,
                        Neighborhood = obj.Address.Neighborhood,
                        Street = obj.Address.Street,
                        Number = obj.Address.Number,
                        Complement = obj.Address.Complement,
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR CREATING USER");
                return new SelectUserModel();
            }
        }
    }
}
