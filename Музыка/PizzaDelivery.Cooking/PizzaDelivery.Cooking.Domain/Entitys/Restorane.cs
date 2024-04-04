using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Entitys;

public class Restorane : Entity<Guid>
{
    private List<RestoraneStocks> _stocks;
    private List<Cooker> _cookers;
    
    public WorkTime WorkTime { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<RestoraneStocks> Stocks { get; private set; }
    public IReadOnlyCollection<Cooker> Cookers { get; private set; }

    public Result AddCooker(Cooker cooker)
    {
        if (cooker.Restorane.Id == Id && this.Cookers.Any(ex => ex.Id == cooker.Id) )
        {
            return Result.Failure("nothing to change");
        }

        if (cooker.Restorane.Id != Id)
        {
            var changeRestoraneResult = cooker.ChangeRestorane(this);

            if (changeRestoraneResult.IsFailure)
            {
                return changeRestoraneResult;
            }
            
        }
        
        _cookers.Add(cooker);

        return Result.Success();
    }

    public Result RemoveCooker(Cooker cooker)
    {
        if (_cookers.Any(ex => ex.Id == cooker.Id) == false)
        {
            return Result.Failure("nothing to change");
        }
        if (cooker.Restorane.Id == Id)
        {
            return Result.Failure("cooker must change restorane before deliting from current");
        }

        _cookers.RemoveAll(ex => ex.Id == cooker.Id);

        return Result.Success();
    }

    
    public Result AddStocks(RestoraneStocks updateInfo){
        return Result.Success();}
    public Result RemoveStocks(RestoraneStocks updateInfo){
        return Result.Success();}
    
    public Result AddStocks(RestoraneStockRecord updateInfo){
        return Result.Success();}
    public Result RemoveStocks(RestoraneStockRecord updateInfo){
        return Result.Success();}

    public Result ChangeAddress(Address address)
    {
        if (Address == address)
        {
            return Result.Failure("nothing to change");
        }

        Address = address;
        return Result.Success();
    }
    public Result ChangeWorkTime(WorkTime timeChange){
        if (timeChange == WorkTime)
        {
            return Result.Failure("nothing to change");
        }

        WorkTime = timeChange;
        return Result.Success();
    }
    
    public Result CanExecuteOrder(Order order)
    {
        if (WorkTime.CanCreateOrder() == false)
        {
            return Result.Failure("Restoran dont get orders");
        }

        if (false == false)//stocks check
        {
            return Result.Failure("dont have ingridients");
        }
        return Result.Success();
    }
    
}