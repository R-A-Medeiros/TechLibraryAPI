using System;
using CommonTestUtilities.Requests;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book;
using FluentAssertions;
using Xunit;

namespace FCxLabs.TechLibraryAPI.Tests.Book.Register;

public class RegisterBookTests
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new BookValidator();
        var request = RequestBookJsonBuilder.Build();


        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue(); 
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Error_Title_Empty(string title)
    {
        //Arrange
        var validator = new BookValidator();
        var request = RequestBookJsonBuilder.Build();
        request.Title = title;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The title is required."));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Error_Genre_Empty(string genre)
    {
        //Arrange
        var validator = new BookValidator();
        var request = RequestBookJsonBuilder.Build();
        request.Genre = genre;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("The genre is required."));
    }

    [Fact]
    public void Error_Date_Future()
    {
        //Arrange
        var validator = new BookValidator();
        var request = RequestBookJsonBuilder.Build();
        request.PublicationYear = request.PublicationYear = new DateOnly(DateTime.UtcNow.Year + 1, 6, 12);

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Publication date cannot be in the future."));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-4)]
    [InlineData(-359)]
    public void Error_AuthorId_Invalid(int id)
    {
        //Arrange
        var validator = new BookValidator();
        var request = RequestBookJsonBuilder.Build();
        request.AuthorId = id;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("Author ID must be greater than 0."));
    }
}
