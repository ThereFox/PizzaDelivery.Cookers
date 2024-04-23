using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Product : Entity<Guid>
{
    private readonly List<ModificationTechologyCard> _modification;
    
    public Order Order { get; }
    public Cooker? Creater { get; private set; }
    public ProductCookState State { get; private set; }
    
    public ProductTechnologyCard BaseProduct { get; }
    public IReadOnlyCollection<ModificationTechologyCard> ModificationsContainings { get; }
    
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
        ProductTechnologyCard baseProductTechnologyCard,
        List<ModificationTechologyCard> modifications,
        Cooker cooker,
        ProductCookState state)
    {
        Id = id;
        BaseProduct = baseProductTechnologyCard;
        _modification = modifications;
        Creater = cooker;
        State = state;
    }

    public static Result<Product> Create(
        Guid id,
        ProductTechnologyCard productTechnologyCard,
        List<ModificationTechologyCard> modifications,
        Cooker cooker,
        ProductCookState state)
    {

        if (modifications is null)
        {
            return Result.Failure<Product>("modification cant be null");
        }
        
        return Result.Success<Product>(new Product(id, productTechnologyCard, modifications, cooker, state));
    }
    
}