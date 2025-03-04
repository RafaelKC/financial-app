namespace FinancialAppBack.Domain.BankAccounts;

public interface IBankAccount
{
    public string Name { get; }
    public string Color { get; }
    public string Image { get; }
    public decimal Balance { get; }
}