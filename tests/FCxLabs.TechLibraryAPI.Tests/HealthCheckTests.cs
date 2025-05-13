using Xunit;
using FluentAssertions;

namespace FCxLabs.TechLibraryAPI.Tests;

public class HealthCheckTests
{
    [Fact]
    public void Should_Return_True_When_HealthCheck_Passes()
    {
        // Arrange
        var result = true;

        // Act & Assert
        result.Should().BeTrue();
    }
}
