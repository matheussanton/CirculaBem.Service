using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CirculaBem.Service.Domain.Entities
{
    [Table("product")]
    public class ProductEntityDomain : BaseEntityDomain
    {
        public ProductEntityDomain() { }

        public ProductEntityDomain(
            string description,
            decimal price,
            Guid categoryId,
            string ownerRegistrationNumber,
            Guid id = default
        ) : base(id)
        {
            Description = description;
            Price = price;
            CategoryId = categoryId;
            OwnerRegistrationNumber = ownerRegistrationNumber;
        }


        [Required]
        [Column("description", TypeName = "varchar(300)")]
        public string Description { get; private set; }

        [Required]
        [Column("price", TypeName = "numeric(8, 2)")]
        public decimal Price { get; private set; } = 0;

        [Required]
        [Column("categoryid", TypeName = "uuid")]
        public Guid CategoryId { get; private set; }

        [Column("ownerregistrationnumber", TypeName = "varchar")]
        public string OwnerRegistrationNumber { get; private set; }

        [NotMapped]
        public List<ProductImageEntityDomain> ImageUrls { get; private set; }
        public void SetImages(List<ProductImageEntityDomain> imageUrls) => ImageUrls = imageUrls;

        [NotMapped]
        public List<ProductAvailabilityEntityDomain> Availabilities { get; private set; }
        public void SetAvailabilities(List<ProductAvailabilityEntityDomain> availabilities) => Availabilities = availabilities;
    }

    [Table("productimage")]
    public class ProductImageEntityDomain : BaseEntityDomain
    {
        public ProductImageEntityDomain() { }

        public ProductImageEntityDomain(
            Guid productId,
            string imageUrl,
            Guid id = default
        ) : base(id)
        {
            ProductId = productId;
            ImageUrl = imageUrl;
        }

        [Required]
        [Column("productid", TypeName = "uuid")]
        public Guid ProductId { get; private set; }

        [Required]
        [Column("imageurl", TypeName = "varchar(300)")]
        public string ImageUrl { get; private set; }
    }


    [Table("productavailability")]
    public class ProductAvailabilityEntityDomain : BaseEntityDomain
    {
        public ProductAvailabilityEntityDomain() { }

        public ProductAvailabilityEntityDomain(
            Guid productId,
            short availability,
            Guid id = default
        ) : base(id)
        {
            ProductId = productId;
            Availability = availability;
        }


        [Required]
        [Column("productid", TypeName = "uuid")]
        public Guid ProductId { get; private set; }

        [Required]
        [Column("availability", TypeName = "int2")]
        public short Availability { get; private set; }
    }
}
