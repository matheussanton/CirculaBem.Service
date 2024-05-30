using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.Product.Enum;
using CirculaBem.Service.Domain.Product.Interfaces;
using CirculaBem.Service.Domain.Product.Models;
using CirculaBem.Service.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CirculaBem.Service.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _context { get; }
        private ILogger<ProductRepository> _logger { get; }

        public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task CreateAsync(ProductEntityDomain product)
        {
            try
            {
                await _context.Products.AddAsync(product);

                foreach (var image in product.ImageUrls)
                {
                    await _context.ProductImages.AddAsync(image);
                }

                foreach (var availability in product.Availabilities)
                {
                    await _context.ProductAvailabilities.AddAsync(availability);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR CREATING PRODUCT");
            }
        }

        public async Task UpdateAsync(ProductEntityDomain product)
        {
            try
            {
                _context.Products.Update(product);

                var productImages = await _context.ProductImages.Where(pi => pi.ProductId == product.Id).ToListAsync();
                var productAvailabilities = await _context.ProductAvailabilities.Where(pa => pa.ProductId == product.Id).ToListAsync();

                _context.ProductImages.RemoveRange(productImages);
                _context.ProductAvailabilities.RemoveRange(productAvailabilities);

                foreach (var image in product.ImageUrls)
                {
                    await _context.ProductImages.AddAsync(image);
                }

                foreach (var availability in product.Availabilities)
                {
                    await _context.ProductAvailabilities.AddAsync(availability);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR UPDATING PRODUCT");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                    return;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR DELETING PRODUCT");
            }
        }

        public async Task<List<SelectProduct>> GetAllByOwnerAsync(string ownerRegistrationNumber)
        {
            try
            {
                var products = _context.Products
                .Select(p => new
                {
                    Product = p,
                    ProductAvailabilities = _context.ProductAvailabilities
                        .Where(pa => pa.ProductId == p.Id)
                        .ToList(),
                })
                .SelectMany(p => p.ProductAvailabilities.DefaultIfEmpty(), (p, pa) => new { p.Product, ProductAvailability = pa })
                .Select(p => new
                {
                    p.Product,
                    p.ProductAvailability,
                    ProductImages = _context.ProductImages
                        .Where(pi => pi.ProductId == p.Product.Id)
                        .ToList(),
                })
                .SelectMany(p => p.ProductImages.DefaultIfEmpty(), (p, pi) => new { p.Product, p.ProductAvailability, ProductImage = pi })
                .Where(p => p.Product.OwnerRegistrationNumber == ownerRegistrationNumber)
                .ToList();





                Dictionary<Guid, SelectProduct> map = new Dictionary<Guid, SelectProduct>();

                foreach (var obj in products)
                {
                    // SelectProduct.Map(product, map);

                    var product = obj.Product;
                    var availability = obj.ProductAvailability;
                    var image = obj.ProductImage;

                    if (!map.ContainsKey(product.Id))
                    {
                        map.Add(product.Id, new SelectProduct
                        {
                            Id = product.Id,
                            Description = product.Description,
                            Price = product.Price,
                            CategoryId = product.CategoryId,
                            OwnerRegistrationNumber = product.OwnerRegistrationNumber,
                            ImageUrls = new List<string>(),
                            Availabilities = new List<EProductAvailability>()
                        });
                    }

                    if (image != null)
                        if (!map[product.Id].ImageUrls.Contains(image.ImageUrl))
                            map[product.Id].ImageUrls.Add(image.ImageUrl);

                    if (availability != null)
                        if (!map[product.Id].Availabilities.Contains((EProductAvailability)availability.Availability))
                            map[product.Id].Availabilities.Add((EProductAvailability)availability.Availability);
                }

                return map.Values.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR GETTING PRODUCTS BY OWNER");
                return new List<SelectProduct>();
            }

        }

        public async Task<List<SelectProduct>> GetAllAsync()
        {
            try
            {
                var products = _context.Products
                .Select(p => new
                {
                    Product = p,
                    ProductAvailabilities = _context.ProductAvailabilities
                        .Where(pa => pa.ProductId == p.Id)
                        .ToList(),
                })
                .SelectMany(p => p.ProductAvailabilities.DefaultIfEmpty(), (p, pa) => new { p.Product, ProductAvailability = pa })
                .Select(p => new
                {
                    p.Product,
                    p.ProductAvailability,
                    ProductImages = _context.ProductImages
                        .Where(pi => pi.ProductId == p.Product.Id)
                        .ToList(),
                })
                .SelectMany(p => p.ProductImages.DefaultIfEmpty(), (p, pi) => new { p.Product, p.ProductAvailability, ProductImage = pi })
                .ToList();





                Dictionary<Guid, SelectProduct> map = new Dictionary<Guid, SelectProduct>();

                foreach (var obj in products)
                {
                    var product = obj.Product;
                    var availability = obj.ProductAvailability;
                    var image = obj.ProductImage;

                    if (!map.ContainsKey(product.Id))
                    {
                        map.Add(product.Id, new SelectProduct
                        {
                            Id = product.Id,
                            Description = product.Description,
                            Price = product.Price,
                            CategoryId = product.CategoryId,
                            OwnerRegistrationNumber = product.OwnerRegistrationNumber,
                            ImageUrls = new List<string>(),
                            Availabilities = new List<EProductAvailability>()
                        });
                    }

                    if (image != null)
                        if (!map[product.Id].ImageUrls.Contains(image.ImageUrl))
                            map[product.Id].ImageUrls.Add(image.ImageUrl);

                    if (availability != null)
                        if (!map[product.Id].Availabilities.Contains((EProductAvailability)availability.Availability))
                            map[product.Id].Availabilities.Add((EProductAvailability)availability.Availability);
                }

                return map.Values.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR GETTING ALL PRODUCTS");
                return new List<SelectProduct>();
            }
        }
    }
}
