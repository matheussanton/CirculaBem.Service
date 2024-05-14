using CirculaBem.Service.Domain.Category.Models;
using MediatR;

namespace CirculaBem.Service.Domain.Category.Queries.Requests
{
    public class GetCategoriesRequest : IRequest<List<SelectCategory>>
    {

    }
}
