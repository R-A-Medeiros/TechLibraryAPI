using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan.Register;

public class RegisterLoanUseCase : IRegisterLoanUseCase
{
    private readonly ILoanWriteOnlyRepository _loanWriteOnlyRepository;
    private readonly IBookCopyReadOnlyRepository _bookCopyReadOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;
    private readonly ILogActionRepository _log;


    public RegisterLoanUseCase(
        ILoanWriteOnlyRepository loanWriteOnlyRepository,
        IBookCopyReadOnlyRepository bookCopyReadOnlyRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ILoggedUser loggedUser,
        ILogActionRepository log)
    {
        _loanWriteOnlyRepository = loanWriteOnlyRepository;
        _bookCopyReadOnlyRepository = bookCopyReadOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
        _log = log;
    }

    public async Task<ResponseRegisteredLoanJson> Execute(RequestLoanJson request)
    {
        Validate(request);

        var loggedUser = await _loggedUser.Get();

        var loan = _mapper.Map<Domain.Entities.Loan>(request);

        loan.UserId = loggedUser.Id;

        var copy = await _bookCopyReadOnlyRepository.GetById(request.BookCopyId);

        if (copy is null)
        {
            throw new NotFoundException($"Book copy with ID {request.BookCopyId} not found.");
        }

        if (copy.IsAvailable == false)
        {
            throw new ErrorOnValidationException(new List<string> { "Book copy is not available for loan." });
        }

        copy.MarkAsLoaned(loan);

        await _loanWriteOnlyRepository.Add(loan);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredLoanJson>(loan);
    }

    public void Validate(RequestLoanJson request)
    {
        var validator = new LoanValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
