using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.User;

public class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";
    private const string ERROR_MESSAGE_VALUE = "Your password must be at least 8 characters long, containing at least one uppercase letter, one lowercase letter, one number and one special character (example @, !, $ ...).";
    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ERROR_MESSAGE_VALUE);
            return false;
        }

        if (value.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ERROR_MESSAGE_VALUE);
            return false;
        }

        if (!Regex.IsMatch(value, @"[A-Z]+"))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ERROR_MESSAGE_VALUE);
            return false;
        }

        if (!Regex.IsMatch(value, @"[a-z]+"))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ERROR_MESSAGE_VALUE);
            return false;
        }

        if (!Regex.IsMatch(value, @"[0-9]+"))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ERROR_MESSAGE_VALUE);
            return false;
        }

        if (!Regex.IsMatch(value, @"[\!\@\#\$\%\&\*\.]+"))
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ERROR_MESSAGE_VALUE);
            return false;
        }

        return true;
    }
}
