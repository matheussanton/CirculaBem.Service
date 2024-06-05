using CirculaBem.Service.Domain.User.Models;
using MediatR;

namespace CirculaBem.Service.Domain.User.Queries.Requests
{
    public class GetUserByRegistrationNumberRequest : IRequest<SelectUserModel>
    {
        public string RegistrationNumber { get; set; }
    }
}
