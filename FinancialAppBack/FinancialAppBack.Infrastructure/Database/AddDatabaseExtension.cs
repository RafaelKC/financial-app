using FinancialAppBack.Infrastructure.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialAppBack.Infrastructure.Database;

public static class AddDatabaseExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<FinancialAppDbContext>(op =>
            {
                op.UseNpgsql(configuration.GetConnectionString("DefaultConnection")); //Here we will use system environment instant of appsettings.json
            })
            .AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        return services;
    }
}