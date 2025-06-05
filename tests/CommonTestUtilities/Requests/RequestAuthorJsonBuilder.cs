using Bogus;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestAuthorJsonBuilder
{
    public static RequestAuthorJson Build()
    {
        //var faker = new Faker();

        //var request = new RequestAuthorJson
        //{
            
        //};

       return new Faker<RequestAuthorJson>()
            .RuleFor(r => r.Name, faker => faker.Person.FirstName + " " + faker.Person.LastName)
            .RuleFor(r => r.Birth, faker => faker.Person.DateOfBirth)
            .RuleFor(r => r.Nationality, faker => faker.Address.Country());

    }
}
