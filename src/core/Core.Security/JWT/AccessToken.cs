﻿namespace Core.Security.JWT;

public class AccessToken
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; } //Token süresi

}
