using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Restorane : Entity<Guid>
{
    private List<RestoraneStocks> _stocks;
    
    public WorkTime WorkTime { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<RestoraneStocks> Stocks { get; private set; }
    public IReadOnlyCollection<Cooker> Cookers { get; private set; }

    public Result CanExecuteOrder(Order order)
    {
        if (WorkTime.CanCreateOrder() == false)
        {
            return Result.Failure("Restoran dont get orders");
        }

        if (haveIngridientForCreateOrder(order) == false)
        {
            return Result.Failure("dont have ingridients");
        }
        return Result.Success();
    }

    private bool haveIngridientForCreateOrder(Order order)
    {
        return true;
    }
    
}