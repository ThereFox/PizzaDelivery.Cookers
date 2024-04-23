using App.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace DAL.Stores;

public class CookersStore : ICookersStore
{
    private readonly ApplicationDBContext _context;

    public CookersStore(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<Result<Cooker>> GetById(Guid id)
    {
        var cooker = await _context
            .Cookers
            .Include(ex => ex.CookingProducts)
            .Include(ex => ex.RestoranDbEntity)
            .FirstAsync(ex => ex.Id == id);

        var validateCookerNameResult = FullName.Create(cooker.FirstName, cooker.MiddleName, cooker.LastName);

        if (validateCookerNameResult.IsFailure)
        {
            return Result.Failure<Cooker>(validateCookerNameResult.Error);
        }

        var cookerRestorane = cooker.RestoranDbEntity;

        if (cookerRestorane is null)
        {
            return Result.Failure<Cooker>("invalid cooker");
        }

        var validateRestoraneWorkTimeResult = WorkTime.Create(cookerRestorane.StartWorkingTime, cookerRestorane.StopWorkingTime);

        if (validateRestoraneWorkTimeResult.IsFailure)
        {
            return Result.Failure<Cooker>(validateRestoraneWorkTimeResult.Error);
        }

        var workTime = validateRestoraneWorkTimeResult.Value;

        var validateRestoraneAddressResult = Address.Create(cookerRestorane.Address);

        if (validateRestoraneAddressResult.IsFailure)
        {
            return Result.Failure<Cooker>(validateRestoraneAddressResult.Error);
        }

        var address = validateRestoraneAddressResult.Value;

        var validateRestoraneResult =
            Restorane.Create(cookerRestorane.Id, workTime, address, null, new List<Cooker>() { cooker } );
        
        var convertedCooker = Cooker.Create();

    }

    public Task<List<Cooker>> GetNMostBusy(int n)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(Cooker cooker)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Create(Cooker cooker)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> Delete(Guid id)
    {
        try
        {
            await _context
                .Cookers
                .Where(ex => ex.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }
}