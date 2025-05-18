using FCxLabs.TechLibraryAPI.Application.AutoMapper;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FCxLabs.TechLibraryAPI.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterAuthorUseCase, RegisterAuthorUseCase>();
    }
}
