using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CirculaBem.Service.Domain.User.Models
{
    public class SelectUserModel
    {
        private class User
        {
            public required string Email { get; set; }
            public required string FullName { get; set; }
        }
    }
}
