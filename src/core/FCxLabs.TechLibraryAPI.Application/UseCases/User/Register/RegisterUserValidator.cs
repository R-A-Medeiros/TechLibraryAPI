using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FluentValidation;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("Name Empty.");
        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email Empty.")
            .EmailAddress()
            .WithMessage("Email Invalid.");

        RuleFor(u => u.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
    }
}
