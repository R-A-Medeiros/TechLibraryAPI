using FCxLabs.TechLibraryAPI.Application.UseCases.User;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace FCxLabs.TechLibraryAPI.Tests.Users;

public class PasswordValidatorTest
{
    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("aaa")]
    [InlineData("aaaa")]
    [InlineData("aaaaa")]
    [InlineData("aaaaaa")]
    [InlineData("aaaaaaa")]
    [InlineData("aaaaaaaa")]
    [InlineData("AAAAAAAA")]
    [InlineData("Aaaaaaaaa")]
    [InlineData("Aaaaaaaa1")]
    [InlineData("Aaaaaaaa!")]
    public void Error_Password_Invalid(string password)
    {
        var validator = new PasswordValidator<RequestRegisterUserJson>();

        // Fix: Provide an instance of RequestRegisterUserJson to the ValidationContext constructor
        var context = new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson());
        var result = validator.IsValid(context, password);

        result.Should().BeFalse();

    }
}
