using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vue3AspNetCore.Domain.Entities.Users.Entities
{
    public class User : BaseEntity
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Role { get; private set; } = string.Empty;
    }
}