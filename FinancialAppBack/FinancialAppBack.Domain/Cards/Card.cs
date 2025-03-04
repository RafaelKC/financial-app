namespace FinancialAppBack.Domain.Cards;

public class Card: Entity, ICard
{
    public string Name { get; private set; }
    public string ImageUrl { get; private set; }
    public string Color { get; private set; }
    public CardBadge Badge { get; private set; }
    public decimal Limit { get; private set; }
    public int DueDay { get; private set; }
    public int BillingCycleDay { get; private set; }
    
    public Card() {}

    public Card(ICard cardModel)
    {
        if (!IsModelValid(cardModel))
            throw new ArgumentException("Invalid card model");
        
        Id = Guid.NewGuid();
        
        Name = cardModel.Name;
        ImageUrl = cardModel.ImageUrl;
        Color = cardModel.Color;
        Badge = cardModel.Badge;
        Limit = cardModel.Limit;
        DueDay = cardModel.DueDay;
        BillingCycleDay = cardModel.BillingCycleDay;
    }
    
    public void Update(ICard cardModel)
    {
        if (!IsModelValid(cardModel))
            throw new ArgumentException("Invalid card model");
        
        Name = cardModel.Name;
        ImageUrl = cardModel.ImageUrl;
        Color = cardModel.Color;
        Badge = cardModel.Badge;
        Limit = cardModel.Limit;
        DueDay = cardModel.DueDay;
        BillingCycleDay = cardModel.BillingCycleDay;
    }
    
    private static bool IsModelValid(ICard cardModel)
    {
        return !string.IsNullOrEmpty(cardModel.Name) && cardModel is { Limit: >= 0, DueDay: >= 1 and <= 31, BillingCycleDay: >= 1 and <= 31 };
    }
}