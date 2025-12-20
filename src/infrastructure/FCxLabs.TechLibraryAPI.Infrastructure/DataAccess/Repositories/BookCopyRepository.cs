using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories
{
    public class BookCopyRepository : IBookCopyReadOnlyRepository
    {

        private readonly TechLibraryDbContext _context;

        public BookCopyRepository(TechLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<BookCopy?> GetById(int bookCopyId)
        {
            return await _context.BookCopies.FirstOrDefaultAsync(c => c.Id == bookCopyId);
        }
    }
}
