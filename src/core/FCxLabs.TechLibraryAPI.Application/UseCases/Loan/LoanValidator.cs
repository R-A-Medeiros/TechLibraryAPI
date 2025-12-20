using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FluentValidation;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan
{
    public class LoanValidator : AbstractValidator<RequestLoanJson>
    {
        public LoanValidator()
        {
            RuleFor(loan => loan.BookCopyId).GreaterThan(0).WithMessage("Book ID must be greater than 0.");
            RuleFor(loan => loan.loanTermDays).GreaterThan(0).WithMessage("Days must be greater than 0.");
        }
    }
}
