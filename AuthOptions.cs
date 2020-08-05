using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SupService
{
    public class AuthOptions
    {
        public const string ISSUER = "SupApplicationBack"; // издатель токена
        public const string AUDIENCE = "SupApplicationFront"; // потребитель токена
        const string KEY = "xecretKeywqejane";   // ключ для шифрации
        public const int LIFETIME = 90; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}