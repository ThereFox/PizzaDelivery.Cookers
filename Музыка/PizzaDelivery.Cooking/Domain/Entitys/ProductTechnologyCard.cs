using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class ProductTechnologyCard : Entity<Guid>
{
    private List<ProductContaining> _containing;
    
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

    public Result UpdateContaining(ProductContaining containing)
    {
        var containingThisIngridient = _containing
            .Where(ex => ex.Ingridient.Id == containing.Ingridient.Id);
        
        if (containingThisIngridient.Any())
        {
            _containing.Remove(containingThisIngridient.First());
            _containing.Add(containing);
            return Result.Success();
        }
        _containing.Add(containing);
        return Result.Success();
    }

    public Result RemoveContaining(ProductContaining containing)
    {
        var containingThisIngridient = _containing
            .Where(ex => ex.Ingridient.Id == containing.Ingridient.Id);
        
        if (containingThisIngridient.Any() == false)
        {
            return Result.Failure("dont have this ingridient");
        }
        
        
        _containing.Remove(containingThisIngridient.First());
        return Result.Success();
        
    }
    
    public static Result<ProductTechnologyCard> Create(Guid id, string name, List<ProductContaining> containings)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<ProductTechnologyCard>("product name must be");
        }

        if (containings is null || containings.Count == 0)
        {
            return Result.Failure<ProductTechnologyCard>("product must have ingridient");
        }
        
        return Result.Success<ProductTechnologyCard>(new ProductTechnologyCard(id, name, containings));
    }

    protected ProductTechnologyCard(Guid id, string name, List<ProductContaining> containings)
    {
        Id = id;
        Name = name;
        _containing = containings;
    }
}