using FinancialAppBack.Domain.BankAccounts;
using FinancialAppBack.Domain.Cards;
using FinancialAppBack.Domain.Categories;
using FinancialAppBack.Domain.People;
using FinancialAppBack.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace FinancialAppBack.Infrastructure.Database;

public sealed class FinancialAppDbContext : DbContext
{
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }

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

        modelBuilder.Entity<Transaction>(mB =>
        {
            mB.ToTable(nameof(Transaction).ToLower());
            mB.Property(t => t.Description).HasMaxLength(450);

            mB.HasOne(t => t.Category)
                .WithOne()
                .HasForeignKey<Transaction>(t => t.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            mB.HasOne(t => t.Person)
                .WithOne()
                .HasForeignKey<Transaction>(t => t.PersonId)
                .OnDelete(DeleteBehavior.SetNull);
            
            mB.HasOne(t => t.Card)
                .WithOne()
                .HasForeignKey<Transaction>(t => t.CardId)
                .OnDelete(DeleteBehavior.Restrict);
            
            mB.HasOne(t => t.AccountTo)
                .WithOne()
                .HasForeignKey<Transaction>(t => t.AccountToId)
                .OnDelete(DeleteBehavior.Restrict);
            
            mB.HasOne(t => t.AccountFrom)
                .WithOne()
                .HasForeignKey<Transaction>(t => t.AccountFromId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Card>().ToTable(nameof(Card).ToLower());
        modelBuilder.Entity<Card>().Property(t => t.Name).HasMaxLength(50);
        modelBuilder.Entity<Card>().Property(t => t.Color).HasMaxLength(7);
        
        
        modelBuilder.Entity<Category>().ToTable(nameof(Category).ToLower());
        modelBuilder.Entity<Category>().Property(t => t.Description).HasMaxLength(50);
        modelBuilder.Entity<Category>().Property(t => t.Color).HasMaxLength(7);
        modelBuilder.Entity<Category>().Property(t => t.Icon).HasMaxLength(20);
        
        modelBuilder.Entity<Person>().ToTable(nameof(Person).ToLower());
        modelBuilder.Entity<Person>().Property(t => t.FirstName).HasMaxLength(50);
        modelBuilder.Entity<Person>().Property(t => t.LastName).HasMaxLength(50);
        
        modelBuilder.Entity<BankAccount>().ToTable(nameof(BankAccount).ToLower());
        modelBuilder.Entity<BankAccount>().Property(t => t.Name).HasMaxLength(50);
        modelBuilder.Entity<BankAccount>().Property(t => t.Color).HasMaxLength(7);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseNpgsql();
        }
    }
}