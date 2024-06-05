using System.ComponentModel.DataAnnotations.Schema;

namespace CirculaBem.Service.Domain.Entities
{
    [Table("user")]
    public class UserEntityDomain
    {
        public UserEntityDomain() { }

        public UserEntityDomain(string firstName, string lastName, string email, string password, string registrationNumber, AddressEntityDomain? address = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            RegistrationNumber = registrationNumber;
            Address = address;
        }

        [Column("firstname", TypeName = "varchar(50)")]
        public string FirstName { get; private set; }
        [Column("lastname", TypeName = "varchar(50)")]
        public string LastName { get; private set; }
        [Column("email", TypeName = "varchar(100)")]
        public string Email { get; private set; }
        [Column("password", TypeName = "varchar")]
        public string Password { get; private set; }
        [Column("isverified", TypeName = "bool")]
        public bool IsVerified { get; private set; } = false;
        [Column("registrationnumber", TypeName = "varchar")]
        public string RegistrationNumber { get; private set; }

        [NotMapped]
        public AddressEntityDomain Address { get; set; }

        public ICollection<ProductEntityDomain> Products { get; set; }
        public ICollection<AddressEntityDomain> Addresses { get; set; }
    }
}
