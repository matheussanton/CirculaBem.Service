using MediatR;

namespace CirculaBem.Service.Domain.Product.Commands
{
    public class BaseProductCommand : IRequest
    {
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<short> Availabilities { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string OwnerRegistrationNumber { get; set; }
    }
}
