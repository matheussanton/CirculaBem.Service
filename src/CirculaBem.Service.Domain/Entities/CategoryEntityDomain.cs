using System.ComponentModel.DataAnnotations.Schema;

namespace CirculaBem.Service.Domain.Entities
{
    [Table("category")]
    public class CategoryEntityDomain : BaseEntityDomain
    {
        public CategoryEntityDomain() { }

        public CategoryEntityDomain(string description, string imageUrl, Guid id = default) : base(id)
        {
            Description = description;
            ImageUrl = imageUrl;
        }

        public string Description { get; init; }
        public string ImageUrl { get; init; }

        public ICollection<ProductEntityDomain> Products { get; set; }
    }
}
