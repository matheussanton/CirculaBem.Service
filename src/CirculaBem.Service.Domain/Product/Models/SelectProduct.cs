using CirculaBem.Service.Domain.Product.Enum;

namespace CirculaBem.Service.Domain.Product.Models
{
    public class SelectProduct
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
        public Guid CategoryId { get; set; }
        public string OwnerRegistrationNumber { get; set; }

        public List<string> ImageUrls { get; set; } = new List<string>();
        public List<EProductAvailability> Availabilities { get; set; } = new List<EProductAvailability>();

        public static void Map(dynamic obj, Dictionary<Guid, SelectProduct> map)
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

            map[product.Id].ImageUrls.Add(image.ImageUrl);
            map[product.Id].Availabilities.Add(availability.Availability);
        }
    }

    public class SelectPoductImage
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; }
    }

    public class SelectProductAvailability
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public EProductAvailability Availability { get; set; }
    }
}
