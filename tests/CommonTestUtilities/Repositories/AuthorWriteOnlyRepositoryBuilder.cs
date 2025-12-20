using FCxLabs.TechLibraryAPI.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public class AuthorWriteOnlyRepositoryBuilder
{
    public static IAuthorRepository Build()
    {
        var mock = new Mock<IAuthorRepository>();

        return mock.Object;
    }
}
