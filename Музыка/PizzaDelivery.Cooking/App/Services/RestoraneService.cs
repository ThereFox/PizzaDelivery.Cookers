using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace App.Services;

public class RestoraneService
{
    private IRestoraneStore _store;

    public RestoraneService(IRestoraneStore store)
    {
        _store = store;
    }

    public async Task<List<Restorane>> GetAll()
    {
        var restorans = await _store.GetAll();
        return restorans;
    }
    public async Task<Result> ChangeRestoraneWorkTime(Guid restoraneId, WorkTime workTime)
    {
        var getRestoraneResult = await _store.GetById(restoraneId);
        
        if (getRestoraneResult.IsFailure)
        {
            return Result.Failure<List<Order>>(getRestoraneResult.Error);
        }

        var restorane = getRestoraneResult.Value;
        var changeResult = restorane.ChangeWorkTime(workTime);

        if (changeResult.IsFailure)
        {
            return changeResult;
        }

        return await _store.SaveChanges(restorane);
    }
    public async Task<Result> ChangeAddress(Guid restoraneId, Address address)
    {
        var getRestoraneResult = await _store.GetById(restoraneId);
        
        if (getRestoraneResult.IsFailure)
        {
            return Result.Failure<List<Order>>(getRestoraneResult.Error);
        }

        var restorane = getRestoraneResult.Value;
        
        var changeResult = restorane.ChangeAddress(address);

        if (changeResult.IsFailure)
        {
            return changeResult;
        }

        return await _store.SaveChanges(restorane);
    }
    public async Task<Result> AddStocks(Guid restoraneId, RestoraneStocks stocks)
    {
        var getRestoraneResult = await _store.GetById(restoraneId);
        
        if (getRestoraneResult.IsFailure)
        {
            return Result.Failure<List<Order>>(getRestoraneResult.Error);
        }

        var restorane = getRestoraneResult.Value;
        
        var changeResult = restorane.AddStocks(stocks);

        if (changeResult.IsFailure)
        {
            return changeResult;
        }

        return await _store.SaveChanges(restorane);
    }
    public async Task<Result<List<Order>>> GetOrders(Guid restoraneId)
    {
        var checkExisting = await _store.GetById(restoraneId);

        if (checkExisting.IsFailure)
        {
            return Result.Failure<List<Order>>(checkExisting.Error);
        }
        
        var orders = await _store.GetCurrentOrders(restoraneId);
        return Result.Success(orders);
    }
    public async Task<Result<List<Cooker>>> GetCookers(Guid restoraneId)
    {
        var getRestoraneResult = await _store.GetById(restoraneId);
        
        if (getRestoraneResult.IsFailure)
        {
            return Result.Failure<List<Cooker>>(getRestoraneResult.Error);
        }

        var restorane = getRestoraneResult.Value;

        return restorane.Cookers.ToList();
    }
    // public async Task<object> GetNeedToBuy(Guid restoraneId)
    // {
    //     var looses = await _store.GetMiddleIngridientLoosesByDay(restoraneId);
    //     
    //     return null;
    // }
}