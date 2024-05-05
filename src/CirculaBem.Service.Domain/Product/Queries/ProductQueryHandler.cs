using CirculaBem.Service.Domain.Product.Interfaces;
using CirculaBem.Service.Domain.Product.Models;
using CirculaBem.Service.Domain.Product.Queries.Requests;
using MediatR;

namespace CirculaBem.Service.Domain.Product.Queries
{

    public class ProductQueryHandler : IRequestHandler<GetUserProductsRequest, List<SelectProduct>>
    {
        private readonly IProductRepository _productRepository;

        public ProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<List<SelectProduct>> Handle(GetUserProductsRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllByOwnerAsync(request.UserRegistrationNumber);
        }
    }
}
