using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.Rent.Interfaces;
using CirculaBem.Service.Infra.Data.Context;
using Microsoft.Extensions.Logging;

namespace CirculaBem.Service.Infra.Data.Repositories
{
    public class RentRepository : IRentRepository
    {
        private AppDbContext _context { get; }
        private ILogger<RentRepository> _logger { get; }

        public RentRepository(AppDbContext context, ILogger<RentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task CreateAsync(RentEntityDomain rent)
        {
            try
            {
                await _context.Rents.AddAsync(rent);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR CREATING RENT");
            }
        }

        public async Task UpdateAsync(RentEntityDomain rent)
        {
            try
            {
                _context.Rents.Update(rent);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR UPDATING RENT");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var rent = await _context.Rents.FindAsync(id);

                if (rent == null)
                    return;

                _context.Rents.Remove(rent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR DELETING RENT");
            }
        }
    }
}
