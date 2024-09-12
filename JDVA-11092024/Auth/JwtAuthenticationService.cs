using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JDVA_11092024.Auth;

public class JwtAuthenticationService : IJwtAuthenticatioService
{
    private readonly string _key;
    public  JwtAuthenticationService(string key)
    {
        _key = key;
    }

    public string Authenticate(string userName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenkey = Encoding.ASCII.GetBytes(_key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,  userName)
            }),

            Expires = DateTime.UtcNow.AddHours(8),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey)
            , SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
