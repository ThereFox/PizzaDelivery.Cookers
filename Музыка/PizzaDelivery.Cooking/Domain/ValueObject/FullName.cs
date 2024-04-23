using CSharpFunctionalExtensions;

namespace PizzaDelivery.Cooking.Domain.ValueObject;

public class FullName : CSharpFunctionalExtensions.ValueObject
{
    public string FirstName { get; }
    public string MiddleName { get; }
    public string LastName { get; }

    protected FullName(string first, string middle, string last)
    {
        FirstName = first;
        MiddleName = middle;
        LastName = last;
    }

    public static Result<FullName> Create(string first, string middle, string last)
    {
        if (
            string.IsNullOrWhiteSpace(first) ||
            string.IsNullOrWhiteSpace(middle) ||
            string.IsNullOrWhiteSpace(last))
        {
            return Result.Failure<FullName>("one parth of name was null or empty");
        }
        return Result.Success(new FullName(first, middle, last));
    }
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return FirstName;
        yield return MiddleName;
        yield return LastName;
    }
}