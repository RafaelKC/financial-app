using FinancialAppBack.Domain.BankAccounts;
using FinancialAppBack.Domain.Cards;
using FinancialAppBack.Domain.Categories;
using FinancialAppBack.Domain.People;

namespace FinancialAppBack.Domain.Transactions;

public class Transaction: Entity, ITransaction
{
    #region Props

    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public bool Applied { get; private set; }
    public decimal Value { get; private set; }
    public TransactionType Type { get; private set; }
    public TransactionDirection Direction { get; private set; }

    // Relations
    public Guid CategoryId { get; private set; }
    public virtual Category Category { get; set; }
    
    public Guid? CardId { get; private set; }
    public virtual Card Card { get; set; }
    
    public Guid? PersonId { get; private set; }
    public virtual Person Person { get; set; }
    
    public Guid? AccountToId { get; private set; }
    public virtual BankAccount AccountTo { get; set; }
    
    public Guid? AccountFromId { get; private set; }
    public virtual BankAccount AccountFrom { get; set; }

    #endregion
    
    public Transaction() {}

    public Transaction(ITransaction transactionModel)
    {
        if (!IsModelValid(transactionModel))
            throw new ArgumentException("Invalid transaction model");
        
        Id = Guid.NewGuid();
        
        Description = transactionModel.Description;
        Date = transactionModel.Date;
        Applied = transactionModel.Applied;
        Value = transactionModel.Value;
        Type = transactionModel.Type;
        Direction = transactionModel.Direction;
    }

    #region Methods

    public void Update(ITransaction transactionModel)
    {
        if (!IsModelValid(transactionModel))
            throw new ArgumentException("Invalid transaction model");
        
        Description = transactionModel.Description;
        Date = transactionModel.Date;
        Applied = transactionModel.Applied;
        Value = transactionModel.Value;
        Type = transactionModel.Type;
        Direction = transactionModel.Direction;
    }

    public void ChangeApplied()
    {
        Applied = true;
    }

    private static bool IsModelValid(ITransaction transactionModel)
    {
        return !string.IsNullOrWhiteSpace(transactionModel.Description) && transactionModel.Value > 0;
    }
    
    #endregion
}