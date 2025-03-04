namespace FinancialAppBack.Domain.Transactions;

public interface ITransaction
{
    public string Description { get; }
    public DateTime Date { get; }
    public bool Applied { get; }
    public decimal Value { get; }
    public TransactionType Type { get; }
    public TransactionDirection Direction { get; }
    
    public Guid CategoryId { get; }
    public Guid? CardId { get; }
    public Guid? PersonId { get; }
    public Guid? AccountToId { get; }
    public Guid? AccountFromId { get; }
}