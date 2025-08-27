using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace FCxLabs.TechLibraryAPI.Infrastructure.Security.Tokens;

public class JwtTokenGeneator : IAccessTokenGenerator
{
    private readonly uint _expirationTimeMinutes;
    private readonly string _signingKey;
    public JwtTokenGeneator(uint expirationTimeMinutes, string signingKey)
    {
        _expirationTimeMinutes = expirationTimeMinutes;
        _signingKey = signingKey;
    }
    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new System.Security.Claims.ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_signingKey);
        return new SymmetricSecurityKey(key);
    }
}
