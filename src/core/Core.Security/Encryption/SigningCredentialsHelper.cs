using Microsoft.IdentityModel.Tokens;

namespace Core.Security.Encryption;

//Bu sınıfın amacı JWT token'ı imzalarken kullanılacak imza bilgilerini (SigningCredentials) oluşturmaktır.
public class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
    }
}
//SecurityKey → Token'ı imzalamak için kullanılan gizli anahtar.
//SecurityAlgorithms.HmacSha512Signature → Kullanılan hash algoritması (HMAC-SHA512).
//SigningCredentials → Token oluştururken imzalama bilgilerini (hangi key ve algoritma) tutar.