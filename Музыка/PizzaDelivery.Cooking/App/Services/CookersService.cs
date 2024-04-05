using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.Filtrs;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace App.Services;

public class CookersService
{
    private readonly IRestoraneStore _restoraneStore;
    private readonly ICookersStore _cookersStore;
    private readonly IProductStore _productStore;

    public async Task<List<Cooker>> GetAll()
    {
        var restorans = await _restoraneStore.GetAll();
        return restorans.SelectMany(ex => ex.Cookers).ToList();
    }
    public async Task<Result<Cooker>> GetById(Guid id)
    {
        var getCookerResult = await _cookersStore.GetById(id);

        return getCookerResult;
    }
    public async Task<List<Cooker>> GetMostBusy()
    {
        var busiest = await _cookersStore.GetNMostBusy(1);
        return busiest;
    }
    public async Task<Result<List<Product>>> GetCreatedProducts(Guid cookerId)
    {
        var haveCookerChackResult = await _cookersStore.GetById(cookerId);
        
        if (haveCookerChackResult.IsFailure)
        {
            return Result.Failure<List<Product>>(haveCookerChackResult.Error);
        }
        
        var filtr = new ProductFiltr([cookerId], [ProductCookState.Cooked]);
        var products = await _productStore.GetWithFiltr(filtr);
        return products;
    }
    public async Task<Result> UpdateName(Guid id, FullName name)
    {
        var cookers = await _cookersStore.GetById(id);

        if (cookers.IsFailure)
        {
            return Result.Failure("dont have cooker");
        }

        var cooker = cookers.Value;

        var changeNameResult = cooker.ChangeFullName(name);

        if (changeNameResult.IsFailure)
        {
            return changeNameResult;
        }

        return await _cookersStore.SaveChanges(cooker);
    }
    public async Task<Result> UpdateRestorane(Guid cookerId, Guid restoraneId)
    {
        var getCookerResult = await _cookersStore.GetById(cookerId);

        if (getCookerResult.IsFailure)
        {
            return getCookerResult;
        }

        var getRestoraneResult = await _restoraneStore.GetById(restoraneId);

        if (getRestoraneResult.IsFailure)
        {
            return getRestoraneResult;
        }
        
        var cooker = getCookerResult.Value;
        var restorane = getRestoraneResult.Value;
        
        return cooker.ChangeRestorane(restorane);
    }
    public async Task<Result> CreateCooker(Cooker cooker)
    {
        return await _cookersStore.Create(cooker);
    }
    public async Task<Result> DeleteCooker(Guid id)
    {
        var getCookerResult = await _cookersStore.GetById(id);

        if (getCookerResult.IsFailure)
        {
            return getCookerResult;
        }

        return await _cookersStore.Delete(id);
    }
    
}