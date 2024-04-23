using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace PizzaDelivery.Cooking.Domain.ValueObject;

public class ProductContaining : CSharpFunctionalExtensions.ValueObject
{
    public Ingridient Ingridient { get; }
    public int Weight { get; }

    protected ProductContaining(Ingridient ingridient, int weight)
    {
        Ingridient = ingridient;
        Weight = weight;
    }

    public Result<ProductContaining> Create(Ingridient ingridient, int weight)
    {
        if (weight < 0)
        {
            return Result.Failure<ProductContaining>("weight must more thero");
        }

        if (weight == 0)
        {
            return Result.Failure<ProductContaining>("dont have practical application");
        }

        return Result.Success<ProductContaining>(new(Ingridient, weight));
    }
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Ingridient;
        yield return Weight;
    }
}