namespace FinancialAppBack.Domain.BankAccounts;

public class BankAccount: Entity, IBankAccount
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public string Image { get; private set; }
    public decimal Balance { get; private set; }
    
    public BankAccount() {}

    public BankAccount(IBankAccount bankAccountModel)
    {
        if (!IsModelValid(bankAccountModel))
            throw new ArgumentException("Invalid bank account model");
        
        Id = Guid.NewGuid();
        
        Name = bankAccountModel.Name;
        Color = bankAccountModel.Color;
        Image = bankAccountModel.Image;
        Balance = bankAccountModel.Balance;
    }
    
    public void Update(IBankAccount bankAccountModel)
    {
        if (!IsModelValid(bankAccountModel))
            throw new ArgumentException("Invalid bank account model");
        
        Name = bankAccountModel.Name;
        Color = bankAccountModel.Color;
        Image = bankAccountModel.Image;
        Balance = bankAccountModel.Balance;
    }

    private static bool IsModelValid(IBankAccount bankAccountModel)
    {
        return !string.IsNullOrEmpty(bankAccountModel.Name) && bankAccountModel.Balance >= 0;
    }
}