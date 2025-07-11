using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly TechLibraryDbContext _context;

    public UserRepository(TechLibraryDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
       return await _context.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User?> GetUserByEmail(string email)
    {
       return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email.Equals(email));
    }
}
