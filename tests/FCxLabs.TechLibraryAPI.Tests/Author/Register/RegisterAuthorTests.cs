
using System;
using CommonTestUtilities.Requests;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author;
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

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Error_Nationality_Empty(string nationality)
    {
        //Arrange
        var validator = new AuthorValidator();
        var request = RequestAuthorJsonBuilder.Build();
        request.Nationality = nationality;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The Nationality is required."));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Error_Name_Empty(string name)
    {
        //Arrange
        var validator = new AuthorValidator();
        var request = RequestAuthorJsonBuilder.Build();
        request.Name = name;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The Name is required."));
    }

    [Fact]
    public void Error_Birthday_Future()
    {
        // Arrange
        var validator = new AuthorValidator();
        var request = RequestAuthorJsonBuilder.Build();
        request.Birth = DateTime.UtcNow.AddDays(1);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Birth cannot be for the future."));
    }
}
