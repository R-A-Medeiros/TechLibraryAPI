using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;
using Microsoft.Extensions.Options;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;

    public RegisterUserUseCase(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
