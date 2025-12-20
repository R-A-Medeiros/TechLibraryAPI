using CommonTestUtilities.Entities;
using CommonTestUtilities.Log;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.Register;
using FCxLabs.TechLibraryAPI.Domain.Entities;
using FluentAssertions;

namespace UseCases.Test.Author;

public class RegisterAuthorUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var loggedUser = UserBuilder.Build();
        var request = RequestAuthorJsonBuilder.Build();
        var useCase = CreateAuthorUseCase(loggedUser);

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);  

    }

    [Fact]
    async Task Error_Name_Empty()
    {
        var loggedUser = UserBuilder.Build();

        var request = RequestAuthorJsonBuilder.Build();
        request.Name = string.Empty;

        var useCase = CreateAuthorUseCase(loggedUser);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<FCxLabs.TechLibraryAPI.Exception.ExceptionsBase.ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains("The Name is required.")); 

    }

    private RegisterAuthorUseCase CreateAuthorUseCase(User user)
    {
        var repository = AuthorWriteOnlyRepositoryBuilder.Build();
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var log = LogUserBuilder.Build(null);
        var loggedUser = LoggedUserBuilder.Build(user);

        return new RegisterAuthorUseCase(repository, unitOfWork, mapper, log, loggedUser);
    }
}
