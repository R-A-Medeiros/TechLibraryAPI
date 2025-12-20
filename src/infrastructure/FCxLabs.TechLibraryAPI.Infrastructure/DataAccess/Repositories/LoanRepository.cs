using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories
{
    public class LoanRepository : ILoanReadOnlyRepository, ILoanWriteOnlyRepository
    {

        private readonly TechLibraryDbContext _context;

        public LoanRepository(TechLibraryDbContext context)
        {
            _context = context;
        }

        public async Task Add(Loan loan)
        {
             await _context.Loans.AddAsync(loan);
        }

        public async Task<List<Loan>> GetAll(long id)
        {
            return await _context.Loans.AsNoTracking()
                                       .Include(l => l.BookCopy)
                                       .ThenInclude(c => c.Book)
                                       .Where(l => l.UserId == id)
                                       .ToListAsync();
        }

        public async Task<Loan?> GetById(int id)
        {
            return await _context.Loans.AsNoTracking()
                                       .FirstOrDefaultAsync(l => l.Id.Equals(id));

       
        }

        public async Task<Loan?> ReturnLoan(long loanId, long userId)
        {
          return await _context.Loans
                      .Include(l => l.BookCopy)
                      .FirstOrDefaultAsync(l => l.Id == loanId &&
                                           l.UserId  == userId &&
                                           l.ReturnedAt == null);
        }
    }
}
