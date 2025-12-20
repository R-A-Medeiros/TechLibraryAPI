using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan.GetAll
{
    public class GetAllLoanUseCase : IGetAllLoanUseCase
    {
        private readonly ILoanReadOnlyRepository _loanReadOnlyRepository;
        private readonly IBookCopyReadOnlyRepository _bookCopyReadOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUser _loggedUser;
        private readonly ILogActionRepository _log;

        public GetAllLoanUseCase(
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

        public async Task<ResponseLoansJson> Execute()
        {
            var loggedUser = await _loggedUser.Get();

            var result = await _loanReadOnlyRepository.GetAll(loggedUser.Id);

            return new ResponseLoansJson
            {
                Loans = _mapper.Map<List<ResponseLoanJson>>(result)
            };


        }
    }
}
