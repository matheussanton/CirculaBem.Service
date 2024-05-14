using CirculaBem.Service.Domain.Category.Interfaces;
using CirculaBem.Service.Domain.Category.Models;
using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CirculaBem.Service.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _context { get; }
        private ILogger<CategoryRepository> _logger { get; }

        public CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task CreateAsync(CategoryEntityDomain category)
        {
            try
            {
                await _context.Categories.AddAsync(category);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR CREATING CATEGORY");
            }
        }

        public async Task UpdateAsync(CategoryEntityDomain category)
        {
            try
            {
                _context.Categories.Update(category);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR UPDATING CATEGORY");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                    return;

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR DELETING CATEGORY");
            }
        }

        public async Task<List<SelectCategory>> GetCategoriesAsync()
        {
            try
            {
                return await _context.Categories.Select(c => new SelectCategory
                {
                    Id = c.Id,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR GETTING CATEGORIES");
                return null;
            }
        }
    }
}
