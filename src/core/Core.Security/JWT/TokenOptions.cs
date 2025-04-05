namespace Core.Security.JWT;

public class TokenOptions
{
    public int AccessTokenExpiration { get; set; }
    //Erişim token’ının kaç dakika geçerli olacağını belirtir.
    public string Audience { get; set; } = string.Empty;
    //Token’ın hangi kullanıcılar/sistemler tarafından kullanılabileceğini belirtir.
    public string Issuer { get; set; } = string.Empty;
    //Token’ı oluşturan sunucunun adını ya da adresini belirtir.
    public string SecurityKey { get; set; } = string.Empty;
    //Token’ı imzalamak için kullanılan gizli anahtar.
}
