using CirculaBem.Service.Domain.Entities;
using MediatR;

namespace CirculaBem.Service.Domain.Product.Commands
{
    public class CreateProductCommand : BaseProductCommand
    {

        public ProductEntityDomain ParseToEntity()
        {
            var productEntity = new ProductEntityDomain
            (
                Name,
                Description,
                Price,
                CategoryId,
                OwnerRegistrationNumber
            );

            var productImages = new List<ProductImageEntityDomain>();
            ImageUrls.ForEach(imageUrl => productImages.Add(new ProductImageEntityDomain(productEntity.Id, imageUrl)));
            productEntity.SetImages(productImages);

            var productAvailabilities = new List<ProductAvailabilityEntityDomain>();
            Availabilities.ForEach(availability => productAvailabilities.Add(new ProductAvailabilityEntityDomain(productEntity.Id, availability)));
            productEntity.SetAvailabilities(productAvailabilities);

            return productEntity;
        }

    }

}
