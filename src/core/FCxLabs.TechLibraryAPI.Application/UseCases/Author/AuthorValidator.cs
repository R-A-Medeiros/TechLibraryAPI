using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FluentValidation;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author;

public class AuthorValidator : AbstractValidator<RequestAuthorJson>
{
    public AuthorValidator()
    {
        RuleFor(author => author.Name).NotEmpty().WithMessage("The Name is required.");
        RuleFor(author => author.Birth).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Birth cannot be for the future.");
        RuleFor(author => author.Nationality).NotEmpty().WithMessage("The Nationality is required.");
    }
}
