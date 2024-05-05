using CirculaBem.Service.Domain.Entities;
using MediatR;

namespace CirculaBem.Service.Domain.Product.Commands
{
    public class CreateProductCommand : IRequest
    {
        public string Description { get; set; }
        public List<string> ImageUrl { get; set; }
        public List<short> Availability { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string OwnerRegistrationNumber { get; set; }

        public ProductEntityDomain ParseToEntity()
        {
            var productEntity = new ProductEntityDomain
            (
                Description,
                Price,
                CategoryId,
                OwnerRegistrationNumber
            );

            var productImages = new List<ProductImageEntityDomain>();
            ImageUrl.ForEach(imageUrl => productImages.Add(new ProductImageEntityDomain(productEntity.Id, imageUrl)));
            productEntity.SetImages(productImages);

            var productAvailabilities = new List<ProductAvailabilityEntityDomain>();
            Availability.ForEach(availability => productAvailabilities.Add(new ProductAvailabilityEntityDomain(productEntity.Id, availability)));
            productEntity.SetAvailabilities(productAvailabilities);

            return productEntity;
        }

    }

}
