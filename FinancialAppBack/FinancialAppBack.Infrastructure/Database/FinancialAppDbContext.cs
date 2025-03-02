using Microsoft.EntityFrameworkCore;

namespace FinancialAppBack.Infrastructure.Database;

public sealed class FinancialAppDbContext: DbContext
{
    public FinancialAppDbContext()
    {
    }
    
    public FinancialAppDbContext(DbContextOptions<FinancialAppDbContext> options, bool migrate = true) : base(options)
    {
        if (migrate)
        {
            Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("public");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseNpgsql(); 
        }
    }
}