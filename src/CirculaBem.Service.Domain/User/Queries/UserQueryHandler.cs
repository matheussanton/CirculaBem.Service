using CirculaBem.Service.Domain.User.Interfaces;
using CirculaBem.Service.Domain.User.Models;
using CirculaBem.Service.Domain.User.Queries.Requests;
using MediatR;

namespace CirculaBem.Service.Domain.User.Queries
{
    public class UserQueryHandler : IRequestHandler<GetUserByRegistrationNumberRequest, SelectUserModel>
    {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<SelectUserModel> Handle(GetUserByRegistrationNumberRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByRegistrationNumberAsync(request.RegistrationNumber);
        }
    }
}
