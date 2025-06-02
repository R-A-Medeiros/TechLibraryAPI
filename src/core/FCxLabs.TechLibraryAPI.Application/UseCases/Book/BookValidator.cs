using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FluentValidation;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book;

public class BookValidator : AbstractValidator<RequestBookJson>
{
    public BookValidator()
    {
        RuleFor(book => book.Title).NotEmpty().WithMessage("The title is required.");
        RuleFor(book => book.Genre).NotEmpty().WithMessage("The genre is required.");
        RuleFor(book => book.PublicationYear).GreaterThan(0).WithMessage("Publication date cannot be in the future.");
        RuleFor(book => book.AuthorId).GreaterThan(0).WithMessage("Author ID must be greater than 0.");
    
    }
}
