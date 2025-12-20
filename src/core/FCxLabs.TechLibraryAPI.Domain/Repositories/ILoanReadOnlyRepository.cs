using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories
{
    public interface ILoanReadOnlyRepository
    {
        Task<Loan?> GetById(int id);

        Task<List<Loan>> GetAll(long id);

        Task<Loan> ReturnLoan(long loanId, long userId);
    }
}
