using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;

public class BookRepository : IBookRepository
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
}
