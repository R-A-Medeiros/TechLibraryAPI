using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Security.Cryptography;
using FCxLabs.TechLibraryAPI.Domain.Security.Tokens;
using FCxLabs.TechLibraryAPI.Infrastructure.DataAccess.Repositories;
using FCxLabs.TechLibraryAPI.Infrastructure.Security.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FCxLabs.TechLibraryAPI.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddToken(services, configuration);
        AddRepositories(services);

        services.AddScoped<IPasswordEncripter, Infrastructure.Security.BCrypt>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGeneator(expirationTimeMinutes, signingKey!));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IAuthorUpdateOnlyRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookReadOnlyRepository, BookRepository>();
        services.AddScoped<IAuthorReadOnlyRepository, AuthorRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }
}
