namespace FinancialAppBack.Domain.Categories;

public interface ICategory
{
    public string Description { get; }
    public string Icon { get; }
    public string Color { get; }
}