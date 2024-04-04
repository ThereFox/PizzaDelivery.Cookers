using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Cooker : Entity<Guid>
{
    public FullName Name { get; private set; }
    public Restorane Restorane { get; private set; }
    private Cooker(Guid id, FullName name, Restorane restorane)
    {
        Id = id;
        Name = name;
        Restorane = restorane;
    }

    public static Result<Cooker> Create(Guid id, FullName name, Restorane restorane)
    {
        return Result.Success<Cooker>(new(id, name, restorane));
    }

    public Result ChangeRestorane(Restorane restorane)
    {
        if (Restorane.Id == restorane.Id)
        {
            return Result.Failure("nothing to change");
        }

        if (restorane.Cookers.Any(ex => ex.Id == Id) == false)
        {
            var removeCookerResult = Restorane.RemoveCooker(this);
            
            if (removeCookerResult.IsFailure)
            {
                return removeCookerResult;
            }
            
            var addCookerResult = Restorane.AddCooker(this);

            if (addCookerResult.IsFailure)
            {
                return addCookerResult;
            }
        }
        
        Restorane = restorane;
        return Result.Success();
    }
    
}