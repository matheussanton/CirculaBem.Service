using System.Net;
using CirculaBem.Service.Domain.Product.Interfaces;
using CirculaBem.Service.Domain.Responses;
using CirculaBem.Service.Domain.Responses.Enums;
using MediatR;

namespace CirculaBem.Service.Domain.Product.Commands.Handler
{
    public class ProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly Response _response;

        public ProductHandler(IProductRepository userRepository, Response response)
        {
            _productRepository = userRepository;
            _response = response;
        }


        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.ParseToEntity();

            await _productRepository.CreateAsync(product);

            _response.Send(ResponseStatus.Success, HttpStatusCode.OK);
        }
    }
}
