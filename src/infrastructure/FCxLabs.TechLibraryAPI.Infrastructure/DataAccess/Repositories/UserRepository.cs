using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository
{
    private readonly TechLibraryDbContext _context;

    public UserRepository(TechLibraryDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
       return await _context.Users.AnyAsync(user => user.Email.Equals(email));
    }
}
