using Bogus;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestBookJsonBuilder
    {
        public static RequestBookJson Build()
        {
            return new Faker<RequestBookJson>()
                 .RuleFor(r => r.Title, faker => faker.Lorem.Sentence(3))
                 .RuleFor(r => r.Genre, faker => faker.Commerce.Categories(1)[0])
                 .RuleFor(r => r.PublicationYear, faker => faker.Date.Past(20).Year)
                 .RuleFor(r => r.AuthorId, faker => faker.Random.Int());
                 

        }
    }
}
