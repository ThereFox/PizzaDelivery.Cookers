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

    public async Task<List<Restorane>> GetAllByPage(int page, int pageSize)
    {
        if (page < 0 || pageSize <= 0)
        {
            throw new InvalidCastException("invalid pageInfo");
        }
        
        var restorans = await _store.GetAllByPage(page, pageSize);
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
}