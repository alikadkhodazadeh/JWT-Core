using System.Security.Cryptography;
using System.Text;

public class SecurityHelper
{
    public static string GetSha256Hash(string value)
    {
        using var sha256 = SHA256.Create();
        byte[] byteValue = Encoding.UTF8.GetBytes(value);
        byte[] byteHash = sha256.ComputeHash(byteValue);
        return Convert.ToBase64String(byteHash);
    }
}
