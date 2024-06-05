using CirculaBem.Service.Domain.User.Models;

namespace CirculaBem.Service.Domain.User.DTO
{
    public class UserDTO : SelectUserModel
    {
        public string Token { get; set; }
    }
}
