namespace FinancialAppBack.Domain.Cards;

public interface ICard
{
    public string Name { get; }
    public string ImageUrl { get; }
    public string Color { get; }
    public CardBadge Badge { get; }
    public decimal Limit { get; }
    public int DueDay { get; }
    public int BillingCycleDay { get; }
}