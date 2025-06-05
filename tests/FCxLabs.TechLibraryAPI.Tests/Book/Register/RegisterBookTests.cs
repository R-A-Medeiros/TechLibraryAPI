using CommonTestUtilities.Requests;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book;
using FluentAssertions;
using Xunit;

namespace FCxLabs.TechLibraryAPI.Tests.Book.Register
{
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
    }
}
