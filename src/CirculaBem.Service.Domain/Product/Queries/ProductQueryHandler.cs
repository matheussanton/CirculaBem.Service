using CirculaBem.Service.Domain.Product.Interfaces;
using CirculaBem.Service.Domain.Product.Models;
using CirculaBem.Service.Domain.Product.Queries.Requests;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CirculaBem.Service.Domain.Product.Queries
{

    public class ProductQueryHandler : IRequestHandler<GetUserProductsRequest, List<SelectProduct>>,
                                       IRequestHandler<GetAllProductsRequest, List<SelectProduct>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _configuration;

        public ProductQueryHandler(IProductRepository productRepository, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _configuration = configuration;
        }


        public async Task<List<SelectProduct>> Handle(GetUserProductsRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllByOwnerAsync(request.UserRegistrationNumber);
        }

        public async Task<List<SelectProduct>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
