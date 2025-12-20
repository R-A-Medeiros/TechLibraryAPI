using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan.GetById;

public class GetByIdLoanUseCase : IGetByIdLoanUseCase
{

    private readonly ILoanReadOnlyRepository _loanReadOnlyRepository;
    private readonly IBookCopyReadOnlyRepository _bookCopyReadOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;
    private readonly ILogActionRepository _log;


    public GetByIdLoanUseCase(
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

    public async Task<ResponseLoanJson> Execute(int id)
    {
        var loan = await _loanReadOnlyRepository.GetById(id);
        if (loan == null)
        {
             throw new NotFoundException($"Loan with ID {id} not found.");           
        }

        return _mapper.Map<ResponseLoanJson>(loan);
    }
}
