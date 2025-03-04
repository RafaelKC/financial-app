using FinancialAppBack.Application.AutoTransient;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialAppBack.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAutoTransients(this IServiceCollection services)
    {
        services.Scan(scan => scan
                .FromApplicationDependencies()
                .AddClasses(classes => classes.AssignableTo<IAutoTransient>())
                .AsImplementedInterfaces()
                .WithTransientLifetime()
        );

        return services;
    }
}