using System.Security.Cryptography;
using System.Text;

namespace Orama_API
{
    public class PasswordHelper
    {
        public static string GenerateSalt()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
        }
        public static string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var combined = password + salt;
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
            return Convert.ToBase64String(hash);
        }
    }
}
//For production apps, use PBKDF2, BCrypt, or Argon2 instead of SHA256.