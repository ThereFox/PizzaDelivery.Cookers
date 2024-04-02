using CSharpFunctionalExtensions;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Ingridient : Entity<Guid>
{
    public string Name { get; }

    protected Ingridient(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Result<Ingridient> Create(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Ingridient>("name must be not null or empty");
        }

        return Result.Success<Ingridient>(new Ingridient(id, name));
    }
    
}