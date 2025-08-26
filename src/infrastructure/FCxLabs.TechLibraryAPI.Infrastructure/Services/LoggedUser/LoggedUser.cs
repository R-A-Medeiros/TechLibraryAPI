using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Security.Tokens;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly TechLibraryDbContext _dbcontext;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(TechLibraryDbContext dbcontext,
                      ITokenProvider tokenProvider)
    {
        _dbcontext = dbcontext;
        _tokenProvider = tokenProvider;
    }
    public async Task<User> Get()
    {
        string token = _tokenProvider.TokenOnRequest();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

       return await _dbcontext.Users
            .AsNoTracking()
            .FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
    }
}
