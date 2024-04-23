using CSharpFunctionalExtensions;

namespace PizzaDelivery.Cooking.Domain.ValueObject;

public class WorkTime : CSharpFunctionalExtensions.ValueObject
{
    private const int PrepairingTimeInMinuts = 15;
    
    public TimeOnly OpenTime { get; }
    public TimeOnly StartOrderingTime { get; }
    public TimeOnly StopOrderingTime { get; }
    public TimeOnly CloseTime { get; }

    public bool CanCreateOrder()
    {
        return TimeOnly.FromDateTime(DateTime.Now) <= StartOrderingTime ||
               TimeOnly.FromDateTime(DateTime.Now) >= StopOrderingTime;
    }
    
    protected WorkTime(TimeOnly openTime, TimeOnly startOrderingTime, TimeOnly stopOrdering, TimeOnly closeTime)
    {
        OpenTime = openTime;
        StartOrderingTime = startOrderingTime;
        StopOrderingTime = stopOrdering;
        CloseTime = closeTime;
    }
    
    public static Result<WorkTime> Create(TimeOnly openTime, TimeOnly closeTime)
    {

        var startOrderingTime = openTime.AddMinutes(PrepairingTimeInMinuts);
        var stopOrderingTime =  TimeOnly.FromTimeSpan(closeTime.ToTimeSpan().Subtract(TimeSpan.FromMinutes(PrepairingTimeInMinuts)));
        
        return Result.Success<WorkTime>( new WorkTime(openTime, startOrderingTime, stopOrderingTime, closeTime));
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return OpenTime;
        yield return StartOrderingTime;
        yield return StopOrderingTime;
        yield return CloseTime;
    }
}