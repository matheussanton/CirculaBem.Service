using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CirculaBem.Service.Domain.Entities
{
    [Table("rent")]
    public class RentEntityDomain : BaseEntityDomain
    {

        public RentEntityDomain() { }

        public RentEntityDomain(string userRegistrationNumber,
                                Guid productId,
                                DateTime startDate,
                                DateTime endDate,
                                Guid id = default) : base(id)
        {
            UserRegistrationNumber = userRegistrationNumber;
            ProductId = productId;
            StartDate = startDate;
            EndDate = endDate;
        }

        [Required]
        [Column("userRegistrationNumber", TypeName = "varchar")]
        public string UserRegistrationNumber { get; set; }
        [ForeignKey("userRegistrationNumber")]
        public UserEntityDomain User { get; set; }


        [Required]
        [Column("productid", TypeName = "uuid")]
        public Guid ProductId { get; set; }
        [ForeignKey("productid")]
        public ProductEntityDomain Product { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
