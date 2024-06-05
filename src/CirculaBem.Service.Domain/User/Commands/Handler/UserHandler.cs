using System.Net;
using CirculaBem.Service.Domain.Hash;
using CirculaBem.Service.Domain.Responses.Enums;
using CirculaBem.Service.Domain.User.Interfaces;
using CirculaBem.Service.Domain.Responses;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CirculaBem.Service.Domain.User.Commands.Handler
{
    public class UserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly Response _response;
        private readonly IConfiguration _configuration;

        public UserHandler(IUserRepository userRepository, Response response, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _response = response;
            _configuration = configuration;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = Hasher.Hash(request.Password);
            request.RegistrationNumber = Encrypter.Encrypt(request.RegistrationNumber, _configuration["Settings:EncryptionKey"]!);

            request.Address.UserRegistrationNumber = request.RegistrationNumber;

            var record = await _userRepository.GetByEmailAsync(request.Email);
            if (record != null)
            {
                request.AddNotification("Email", "Email já cadastrado");
                _response.Send(ResponseStatus.Fail, HttpStatusCode.BadRequest, request.Notifications);
                return;
            }

            var user = request.Parse();
            await _userRepository.CreateAsync(user);

            return;
        }
    }
}
