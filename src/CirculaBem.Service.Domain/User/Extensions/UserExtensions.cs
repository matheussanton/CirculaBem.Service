using CirculaBem.Service.Domain.Entities;

namespace CirculaBem.Service.Domain.User.Extensions
{
    public static class UserExtensions
    {
        public static string GetFullName(this UserEntityDomain user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
