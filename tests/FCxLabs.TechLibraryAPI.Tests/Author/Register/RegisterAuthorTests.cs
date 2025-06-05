
using System;
using CommonTestUtilities.Requests;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FluentAssertions;
using Xunit;

namespace FCxLabs.TechLibraryAPI.Tests.Author.Register;

public class RegisterAuthorTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new AuthorValidator();
        var request = RequestAuthorJsonBuilder.Build();
      

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue(); //Assert.True(result.IsValid);
    }
}
