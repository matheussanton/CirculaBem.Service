using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.User.Interfaces;
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
    }
}
