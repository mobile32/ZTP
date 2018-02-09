﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Write
{
    class PasswordService
    {
        public string HashPassword(string password, string salt)
        {
            using (var algorithm = SHA256.Create())
            {
                var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(salt + password + salt));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
