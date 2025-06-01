using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;

public class AuthorRepository : IAuthorRepository, IAuthorUpdateOnlyRepository, IAuthorReadOnlyRepository
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

    public void Delete(Author author)
    {

        _context.Authors.Remove(author!);
    }

    public async Task<List<Author>> GetAll()
    {
        return await _context.Authors
            .AsNoTracking()
            .Include(a => a.Books)
            .ToListAsync();
    }

    public async Task<Author?> GetById(int id)
    {
        return await _context.Authors
            .AsNoTracking()
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

     async Task<Author?> IAuthorReadOnlyRepository.GetById(int id)
    {
        return await _context.Authors
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public void Update(Author author)
    {
        _context.Authors.Update(author);
    }

}
