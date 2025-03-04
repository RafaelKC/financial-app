namespace FinancialAppBack.Domain.Categories;

public class Category: Entity, ICategory
{
    public string Description { get; private set; }
    public string Icon { get; private set; }
    public string Color { get; private set; }
    
    public Category() {}

    public Category(ICategory categoryModel)
    {
        if (!IsModelValid(categoryModel))
            throw new ArgumentException("Invalid category model");
        
        Id = Guid.NewGuid();
        
        Description = categoryModel.Description;
        Icon = categoryModel.Icon;
        Color = categoryModel.Color;
    }

    public void Update(ICategory categoryModel)
    {
        if (!IsModelValid(categoryModel))
            throw new ArgumentException("Invalid category model");
        
        Description = categoryModel.Description;
        Icon = categoryModel.Icon;
        Color = categoryModel.Color;   
    }
    
    private static bool IsModelValid(ICategory bankAccountModel)
    {
        return !string.IsNullOrEmpty(bankAccountModel.Description);
    }
}