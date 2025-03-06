using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vue3AspNetCore.Domain.Entities.Authentications.Entities
{
    public class LoginUser
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// パスワード
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}