using DML.Application.Journal.Commands;
using DML.Application.SignUp.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DML.Application.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<SignUpCommand>();
        services.AddScoped<SignInCommnad>();
        services.AddScoped<CreateJournalCommand>();
        services.AddScoped<GetJournalCommand>();

        return services;
    }
}
