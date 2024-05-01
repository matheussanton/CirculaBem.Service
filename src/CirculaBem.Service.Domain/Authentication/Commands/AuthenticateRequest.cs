using Flunt.Notifications;
using MediatR;

namespace CirculaBem.Service.Domain.Authentication.Commands
{
    public class AuthenticateRequest : Notifiable<Notification>, IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
