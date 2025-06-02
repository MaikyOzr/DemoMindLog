using DML.Application.SignUp.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DML.Application.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register your application services here
        // Example: services.AddScoped<IMyAppService, MyAppService>();
        services.AddScoped<SignUpCommand>();
        services.AddScoped<SignInCommnad>();

        return services;
    }
}
