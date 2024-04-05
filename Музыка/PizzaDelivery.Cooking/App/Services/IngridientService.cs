using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Services;

public class IngridientService
{
    private readonly IIngridientsStore _ingridientsStore;
    public async Task<List<Ingridient>> GetAll()
    {
        var getIngridients = await _ingridientsStore.GetAll();
        return getIngridients;
    }
    public async Task<List<Ingridient>> GetFiveMostUsable()
    {
        var mostUsable = await _ingridientsStore.GetNMostUsed(5);
        return mostUsable;
    }
    public async Task<List<Ingridient>> GetFiveLowUsable()
    {
        var lowUsable = await _ingridientsStore.GetNLowUsed(5);
        return lowUsable;
    }
    public async Task<Result> ChangeIngridientName(Guid ingridientId, string newName)
    {
        var getIngridientResult = await _ingridientsStore.GetById(ingridientId);
        
        if (getIngridientResult.IsFailure)
        {
            return getIngridientResult;
        }

        var ingridient = getIngridientResult.Value;

        var changePhoneResult = ingridient.ChangeName(newName);

        if (changePhoneResult.IsFailure)
        {
            return changePhoneResult;
        }

        var updateResult = await _ingridientsStore.SaveChanges(ingridient);
        
        return updateResult;
    }
    public async Task<Result> Create(Ingridient ingridient)
    {
        return await _ingridientsStore.Create(ingridient);
    }
    public async Task<Result> Delete(Guid id)
    {
        return await _ingridientsStore.Delete(id);
    }

}