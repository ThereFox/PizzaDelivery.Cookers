namespace PizzaDelivery.Cooking.Domain.ValueObject;

public class ProductCookState : CSharpFunctionalExtensions.ValueObject
{
    public static ProductCookState NotDistributed => new ProductCookState(0);
    public static ProductCookState InCook => new ProductCookState(1);
    public static ProductCookState Cooked => new ProductCookState(2);
    
    public int State { get; }

    protected ProductCookState(int state)
    {
        State = state;
    }
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return State;
    }
}