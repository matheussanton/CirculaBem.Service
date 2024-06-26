using System.Text.Json.Serialization;
using CirculaBem.Service.Domain.Address.Commands;
using CirculaBem.Service.Domain.Entities;
using Flunt.Notifications;
using MediatR;

namespace CirculaBem.Service.Domain.User.Commands
{
    public class CreateUserCommand : Notifiable<Notification>, IRequest
    {
        [JsonPropertyName("name")]
        public string FirstName { get; set; }
        [JsonPropertyName("surName")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("pwd")]
        public string Password { get; set; }
        [JsonPropertyName("regNum")]
        public string RegistrationNumber { get; set; }

        public CreateAddressCommand Address { get; set; }


        public UserEntityDomain Parse()
        {
            return new UserEntityDomain(
                FirstName,
                LastName,
                Email,
                Password,
                RegistrationNumber,
                Address.ParseToEntity()
            );
        }
    }
}
