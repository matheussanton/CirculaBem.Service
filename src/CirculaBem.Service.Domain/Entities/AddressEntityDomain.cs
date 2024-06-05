using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CirculaBem.Service.Domain.Entities
{
    [Table("adresses")]
    public class AddressEntityDomain : BaseEntityDomain
    {
        public AddressEntityDomain() { }
        public AddressEntityDomain(
            string userRegistrationNumber,
            string cep,
            string state,
            string city,
            string neighborhood,
            string street,
            short number,
            string complement,
            Guid id = default
        ) : base(id)
        {
            UserRegistrationNumber = userRegistrationNumber;
            Cep = cep;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Street = street;
            Number = number;
            Complement = complement;
        }

        [Required]
        [Column("userregistrationnumber", TypeName = "varchar")]
        public string UserRegistrationNumber { get; private set; }
        [ForeignKey("UserRegistrationNumber")]
        public UserEntityDomain User { get; set; }

        [Required]
        [Column("cep", TypeName = "varchar(8)")]
        public string Cep { get; private set; }

        [Required]
        [Column("state", TypeName = "char(2)")]
        public string State { get; private set; }

        [Required]
        [Column("city", TypeName = "varchar(100)")]
        public string City { get; private set; }

        [Required]
        [Column("neighborhood", TypeName = "varchar(100)")]
        public string Neighborhood { get; private set; }

        [Required]
        [Column("street", TypeName = "varchar(100)")]
        public string Street { get; private set; }

        [Required]
        [Column("number", TypeName = "smallint")]
        public short Number { get; private set; }

        [Column("complement", TypeName = "varchar(100)")]
        public string Complement { get; private set; }
    }
}
