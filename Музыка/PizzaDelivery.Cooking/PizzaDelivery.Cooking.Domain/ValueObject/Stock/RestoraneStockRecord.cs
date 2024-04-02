using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace PizzaDelivery.Cooking.Domain.ValueObject;

public class RestoraneStockRecord
{
    public Ingridient Ingridient { get; }
    public int Gramms { get; private set; }

    public bool CanRealise()
    {
        
    }

    public Result Remove()
    {
        
    }

    
}