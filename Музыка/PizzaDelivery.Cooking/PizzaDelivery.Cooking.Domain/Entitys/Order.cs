using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Order : Entity<Guid>
{
    private List<Product> _elements;
    public OrderState State { get; private set; }
    public string Code { get; }
    public DateTime OrderTime { get; }
    public IReadOnlyCollection<Product> Composition { get; }


    protected Order(Guid id, string code, DateTime orderTime, List<Product> products)
    {
        Id = id;
        Code = code;
        OrderTime = orderTime;
        Composition = products;
    }

    public static Result<Order> Create(Guid id, string code, DateTime orderTime, List<Product> products)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return Result.Failure<Order>("code must be");
        }

        if (orderTime > DateTime.Now)
        {
            return Result.Failure<Order>("invalid order time");
        }

        if (products is null || products.Count == 0)
        {
            return Result.Failure<Order>("dont have product in order");
        }

        return Result.Success(new Order(id, code, orderTime, products));

    }
    
}