using System.Net;
using CirculaBem.Service.Domain.Category.Interfaces;
using CirculaBem.Service.Domain.Responses;
using CirculaBem.Service.Domain.Responses.Enums;
using MediatR;

namespace CirculaBem.Service.Domain.Category.Commands.Handler
{
    public class CategoryHandler : IRequestHandler<CreateCategoryCommand>,
                                   IRequestHandler<UpdateCategoryCommand>,
                                   IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly Response _response;

        public CategoryHandler(ICategoryRepository categoryRepository, Response response)
        {
            _categoryRepository = categoryRepository;
            _response = response;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.Parse();

            await _categoryRepository.CreateAsync(category);

            _response.Send(ResponseStatus.Success, HttpStatusCode.OK);
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.Parse();

            await _categoryRepository.UpdateAsync(category);

            _response.Send(ResponseStatus.Success, HttpStatusCode.OK);
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(request.Id);

            _response.Send(ResponseStatus.Success, HttpStatusCode.OK);
        }
    }
}
