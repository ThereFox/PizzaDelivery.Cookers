using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace PizzaDelivery.Cooking.Domain.ValueObject;

public class RestoraneStocks
{
    private List<RestoraneStockRecord> _elements;

    public IReadOnlyCollection<RestoraneStockRecord> Elements => _elements;
    
    public bool CanRealise(Order order)
    {
        return true;
    }

    public Result RemoveUsedIngridient(Order order)
    {
        return Result.Success();
    }
    
    

}