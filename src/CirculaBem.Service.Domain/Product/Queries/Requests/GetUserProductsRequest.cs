using CirculaBem.Service.Domain.Product.Models;
using MediatR;

namespace CirculaBem.Service.Domain.Product.Queries.Requests
{
    public class GetUserProductsRequest : IRequest<List<SelectProduct>>
    {
        public string UserRegistrationNumber { get; set; }
    }
}
