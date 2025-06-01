using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;

public class BookRepository : IBookRepository, IBookReadOnlyRepository
{
    private readonly TechLibraryDbContext _context;

    public BookRepository(TechLibraryDbContext context)
    {
        _context = context;
    }
    public async Task Add(Book book)
    {
        await _context.Books.AddAsync(book);
    }

    public void Delete(Book book)
    {
        _context.Books.Remove(book);
    }

    public async Task<List<Book>> GetAll()
    {
        return await _context.Books
            .AsNoTracking()
            .Include(b => b.Author)
            .ToListAsync();
    }

    public async Task<Book?> GetById(int id)
    {
        return await _context.Books
            .AsNoTracking()
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public void Update(Book book)
    {
       _context.Books .Update(book);
    }

    async Task<Book?> IBookReadOnlyRepository.GetById(int id)
    {
        return await _context.Books
            .FirstOrDefaultAsync(x => x.Id == id);
    }

}
