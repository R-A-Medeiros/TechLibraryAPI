using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;

public class AuthorRepository : IAuthorRepository, IAuthorUpdateOnlyRepository
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

    public async Task Delete(int id)
    {
        var result = await _context.Authors.FirstAsync(a => a.Id == id);
        _context.Authors.Remove(result!);        
    }

    public async Task<List<Author>> GetAll()
    {
        return await _context.Authors
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Author?> GetById(int id)
    {
        return await _context.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

     async Task<Author?> IAuthorUpdateOnlyRepository.GetById(int id)
    {
        return await _context.Authors
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public void Update(Author author)
    {
        _context.Authors.Update(author);
    }
}
