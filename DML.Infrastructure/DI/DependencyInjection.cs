using DML.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DML.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // Register your infrastructure services here
        // Example: services.AddSingleton<IMyService, MyService>();

        services.AddDbContext<AppDbContext>(
            opt => opt.UseNpgsql(config.GetConnectionString("DefaultConnection"))
        );

        return services;
    }
}
