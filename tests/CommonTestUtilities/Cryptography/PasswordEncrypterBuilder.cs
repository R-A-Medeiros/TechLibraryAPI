using FCxLabs.TechLibraryAPI.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Cryptography;

public class PasswordEncrypterBuilder
{
    private readonly Mock<IPasswordEncripter> _mock;

    public PasswordEncrypterBuilder()
    {
        _mock = new Moq.Mock<IPasswordEncripter>();

        _mock.Setup(passwordEncrypter => passwordEncrypter.Encrypt(It.IsAny<string>())).Returns("!%dlfjkd545");
        //mock.Setup(passwordEncripter => passwordEncripter.Encrypt(It.IsAny<string>())).Returns("string");

        //return mock.Object;
    }

    public PasswordEncrypterBuilder Verify(string? password)
    {
        if (string.IsNullOrWhiteSpace(password) == false)
        {
            _mock.Setup(p => p.Verify(password, It.IsAny<string>())).Returns(true);
        }

        return this;
    }

    public IPasswordEncripter Build() => _mock.Object;
}
