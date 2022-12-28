using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1; 

public static class AuthOptions {
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    public const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
    public const int LIFETIME = 2; // время жизни токена - 1 минута
    public static SymmetricSecurityKey getSymmetricSecurityKey() => new(Encoding.ASCII.GetBytes(KEY));
}