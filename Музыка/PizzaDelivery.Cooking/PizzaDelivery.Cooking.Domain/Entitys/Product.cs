using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Product : Entity<Guid>
{
    private List<ProductContaining> _containing;
    
    public Cooker? Creater { get; private set; }
    public ProductCookState State { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<ProductContaining> IngridientContaining => _containing;

    public Result ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            return Result.Failure("name must be not null or empty");
        }
        
        Name = newName;

        return Result.Success();
    }

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
    
    protected Product(Guid id, string name, Cooker cooker, ProductCookState state, List<ProductContaining> containing)
    {
        Id = id;
        Name = name;
        Creater = cooker;
        State = state;
        _containing = containing;
    }

    public static Result<Product> Create(Guid id, string name, Cooker cooker, ProductCookState state, List<ProductContaining> containing)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Product>("product name must be");
        }

        if (containing is null || containing.Count == 0)
        {
            return Result.Failure<Product>("product must have ingridient");
        }
        return Result.Success<Product>(new Product(id, name, cooker, state, containing));
    }
    
}