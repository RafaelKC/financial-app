namespace FinancialAppBack.Domain.People;

public class Person : Entity, IPerson
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Person()
    {
    }

    public Person(IPerson personMode)
    {
        if (!IsModelValid(personMode))
            throw new ArgumentException("Invalid person model");
        
        Id = Guid.NewGuid();

        FirstName = personMode.FirstName;
        LastName = personMode.LastName;
    }

    public void Update(IPerson personMode)
    {
        if (!IsModelValid(personMode))
            throw new ArgumentException("Invalid person model");

        
        FirstName = personMode.FirstName;
        LastName = personMode.LastName;
    }
    
    private static bool IsModelValid(IPerson bankAccountModel)
    {
        return !string.IsNullOrEmpty(bankAccountModel.FirstName) && !string.IsNullOrEmpty(bankAccountModel.LastName);
    }
}