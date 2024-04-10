using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Product : Entity<Guid>
{
    private readonly List<ModificationInfo> _modification;
    
    public Order Order { get; }
    public Cooker? Creater { get; private set; }
    public ProductCookState State { get; private set; }
    
    public ProductInfo BaseProduct { get; }
    public IReadOnlyCollection<ModificationInfo> ModificationsContainings { get; }
    
    public Result SetCooker(Cooker creater)
    {
        if (State == ProductCookState.Cooked)
        {
            return Result.Failure("Is sealed order");
        }
        
        Creater = creater;
        return Result.Success();
    }
    public Result ChangeState(ProductCookState newState)
    {
        if (State == ProductCookState.Cooked)
        {
            return Result.Failure("Is sealed order");
        }

        State = newState;
        return Result.Success();
    }

    
    protected Product(
        Guid id,
        ProductInfo baseProductInfo,
        List<ModificationInfo> modifications,
        Cooker cooker,
        ProductCookState state)
    {
        Id = id;
        BaseProduct = baseProductInfo;
        _modification = modifications;
        Creater = cooker;
        State = state;
    }

    public static Result<Product> Create(
        Guid id,
        ProductInfo productInfo,
        List<ModificationInfo> modifications,
        Cooker cooker,
        ProductCookState state)
    {

        if (modifications is null)
        {
            return Result.Failure<Product>("modification cant be null");
        }
        
        return Result.Success<Product>(new Product(id, productInfo, modifications, cooker, state));
    }
    
}