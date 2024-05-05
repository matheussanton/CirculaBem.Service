using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Domain.Product.Enum;
using CirculaBem.Service.Domain.Product.Interfaces;
using CirculaBem.Service.Domain.Product.Models;
using CirculaBem.Service.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<SelectProduct>> GetAllByOwnerAsync(string ownerRegistrationNumber)
        {
            try
            {
                var products = _context.Products
                                    .Join(
                                        _context.ProductAvailabilities,
                                        p => p.Id,
                                        pa => pa.ProductId,
                                        (p, pa) => new { Product = p, ProductAvailability = pa })
                                    .Join(
                                        _context.ProductImages,
                                        ppa => ppa.Product.Id,
                                        pi => pi.ProductId,
                                        (ppa, pi) => new { Product = ppa.Product, ProductAvailability = ppa.ProductAvailability, ProductImage = pi })
                                    .Where(p => p.Product.OwnerRegistrationNumber == ownerRegistrationNumber)
                                    .Select(joinResult => new { joinResult.Product, joinResult.ProductAvailability, joinResult.ProductImage })
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

                    if (!map[product.Id].ImageUrls.Contains(image.ImageUrl))
                        map[product.Id].ImageUrls.Add(image.ImageUrl);

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
    }
}
