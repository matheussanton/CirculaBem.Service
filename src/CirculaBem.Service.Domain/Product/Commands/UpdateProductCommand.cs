using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.Product.Commands
{
    public class UpdateProductCommand : BaseProductCommand
    {
        public Guid Id { get; private set; }
        public void SetId(Guid id) => Id = id;

        public ProductEntityDomain ParseToEntity()
        {
            var productEntity = new ProductEntityDomain
            (
                Description,
                Price,
                CategoryId,
                OwnerRegistrationNumber,
                Id
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
