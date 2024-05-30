using CirculaBem.Service.Domain.Product.Models;
using MediatR;

namespace CirculaBem.Service.Domain.Product.Queries.Requests
{
    public class GetAllProductsRequest : IRequest<List<SelectProduct>>
    {

    }
}
