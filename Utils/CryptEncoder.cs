using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Utils;

public class CryptEncoder {
    public static string hashPassword(string password, out string salt) {
        var hmac = new HMACSHA512();
        salt = Convert.ToBase64String(hmac.Key);

        return Convert.ToBase64String(
            hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }

    public static bool checkPassword(string password, string hashedPassword, string salt) =>
        new HMACSHA512(Convert.FromBase64String(salt)).ComputeHash(Encoding.UTF8.GetBytes(password))
            .SequenceEqual(Convert.FromBase64String(hashedPassword));
}