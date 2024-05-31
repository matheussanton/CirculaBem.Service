using CirculaBem.Service.Domain.Product.Models;
using MediatR;

namespace CirculaBem.Service.Domain.Product.Queries.Requests
{
    public class GetProductByIdRequest : IRequest<SelectProduct>
    {
        public Guid Id { get; set; }
    }
}
