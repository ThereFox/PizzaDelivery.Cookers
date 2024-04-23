using CSharpFunctionalExtensions;

namespace PizzaDelivery.Cooking.Domain.ValueObject;

public class Address : CSharpFunctionalExtensions.ValueObject
{
    public string FullAddress { get; }

    protected Address(string address)
    {
        FullAddress = address;
    }

    public static Result<Address> Create(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            return Result.Failure<Address>("address must be not null or empty");
        }
        return Result.Success(new Address(address));
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return FullAddress;
    }
}