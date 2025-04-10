﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Security.Encryption;

//Bu sınıf, JWT token'ı imzalarken kullanılacak gizli güvenlik anahtarını (SecurityKey) oluşturur.
public class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
