
using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Enums;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan.ReturnLoan
{
    public class ReturnLoanUseCase : IReturnLoanUseCase
    {
        private readonly ILoanReadOnlyRepository _loanReadOnlyRepository;
        private readonly IBookCopyReadOnlyRepository _bookCopyReadOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUser _loggedUser;
        private readonly ILogActionRepository _log;


        public ReturnLoanUseCase(
            ILoanReadOnlyRepository loanReadOnlyRepository,
            IBookCopyReadOnlyRepository bookCopyReadOnlyRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILoggedUser loggedUser,
            ILogActionRepository log)
        {
            _loanReadOnlyRepository = loanReadOnlyRepository;
            _bookCopyReadOnlyRepository = bookCopyReadOnlyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _loggedUser = loggedUser;
            _log = log;
        }

        public async Task<ResponseLoanJson> Execute(int loanId)
        {
            var user = await _loggedUser.Get();

            var loan = await _loanReadOnlyRepository.ReturnLoan(loanId, user.Id);

            if (loan == null)
            {
                throw new NotFoundException($"Loan with ID {loanId} not found.");
            }

            loan.Return();
            loan.BookCopy.MarkAsReturned();
            loan.Status = LoanStatus.RETURNED;

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseLoanJson>(loan);
        }
    }
}
