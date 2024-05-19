using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CirculaBem.Service.Domain.Entities
{
    [Table("rent")]
    public class RentEntityDomain : BaseEntityDomain
    {

        public RentEntityDomain() { }

        public RentEntityDomain(Guid userId,
                                Guid productId,
                                DateTime startDate,
                                DateTime endDate,
                                Guid id = default) : base(id)
        {
            UserId = userId;
            ProductId = productId;
            StartDate = startDate;
            EndDate = endDate;
        }

        [Required]
        [Column("userId", TypeName = "uuid")]
        public Guid UserId { get; private set; }
        [ForeignKey("UserId")]
        public UserEntityDomain User { get; set; }


        [Required]
        [Column("productid", TypeName = "uuid")]
        public Guid ProductId { get; private set; }
        [ForeignKey("ProductId")]
        public ProductEntityDomain Product { get; set; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}
