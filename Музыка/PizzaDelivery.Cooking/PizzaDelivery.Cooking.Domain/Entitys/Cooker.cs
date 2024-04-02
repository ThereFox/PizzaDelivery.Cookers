using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Cooker : Entity<Guid>
{
    public FullName Name { get; private set; }

    private Cooker(Guid id, FullName name)
    {
        Id = id;
        Name = name;
    }

    public static Result<Cooker> Create(Guid id, FullName name)
    {
        return Result.Success<Cooker>(new(id, name));
    }
    
}