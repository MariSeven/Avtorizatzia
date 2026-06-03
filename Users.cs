using System;
using System.Collections.Generic;
using System.Text;

namespace Avtorizatzia
{
    public static class UserDatabase
    {
        // Список пользователей с паролями
        public static Dictionary<string, string> Users { get; set; } = new Dictionary<string, string>
        {
            { "admin", "12345" },
            { "user1", "qwerty" },
            { "user2", "password" }
        };
    }
}
