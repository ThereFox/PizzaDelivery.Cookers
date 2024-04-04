namespace PizzaDelivery.Cooking.Domain.ValueObject;

public class OrderState : CSharpFunctionalExtensions.ValueObject
{
    public static OrderState AwaitCook => new OrderState(0);
    public static OrderState InCooking => new OrderState(1);
    public static OrderState Cooked => new OrderState(2);
    public static OrderState Canceled => new OrderState(3);
    
    public int State { get; }

    protected OrderState(int state)
    {
        State = state;
    }
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return State;
    }
}