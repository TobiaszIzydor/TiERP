using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Domain.PasswordGenerator
{
    public static class PasswordGenerator
    {
        public static string GenerateUniquePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 24)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
