using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly TechLibraryDbContext _context;
    public AuthorRepository(TechLibraryDbContext context)
    {
        _context = context;
    }
    public async Task Add(Author author)
    {
       await _context.Authors.AddAsync(author); 
    }

    public async Task<List<Author>> GetAll()
    {
        return await _context.Authors
            .AsNoTracking()
            .ToListAsync();
    }
}
