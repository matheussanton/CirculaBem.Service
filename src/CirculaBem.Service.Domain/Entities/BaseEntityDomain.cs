using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CirculaBem.Service.Domain.Entities
{
    public class BaseEntityDomain
    {
        public BaseEntityDomain() { }
        public BaseEntityDomain(
            Guid id = default
        )
        {
            Id = id == default ? Guid.NewGuid() : id;
        }

        [Key]
        [Column("id")]
        public Guid Id { get; private set; }
    }
}
