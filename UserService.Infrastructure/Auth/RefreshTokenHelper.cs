using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace UserService.Infrastructure.Auth
{
    public static class RefreshTokenHelper
    {
        public static string Generate()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(bytes);
        }



        public static string Hash(string token) =>
            Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(token)));







    }
}
