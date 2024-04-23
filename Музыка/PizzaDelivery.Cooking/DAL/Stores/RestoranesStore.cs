using App.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace DAL.Stores;

public class RestoranesStore : IRestoraneStore
{
    protected ApplicationDBContext _context;

    public RestoranesStore(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<Restorane>> GetAllByPage(int pageNumber, int pageSize)
    {
        if (pageNumber < 0)
        {
            throw new InvalidCastException("invalidPageNumber");
        }
        
        var restorans = await _context
            .Restoranes
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var convertedEntitys = restorans.Select(ex =>
        {

            var validateAddress = Address.Create(ex.Address);

            if (validateAddress.IsFailure)
            {
                return null;
            }

            var address = validateAddress.Value;
            
            var validateWorkTime = WorkTime.Create(
                ex.StartWorkingTime, ex.StopWorkingTime);

            if (validateWorkTime.IsFailure)
            {
                return null;
            }

            
            var workTime = validateWorkTime.Value;

            var validateRestorane = Restorane.Create(ex.Id, workTime, address, null, null);

            if (validateRestorane.IsFailure)
            {
                return null;
            }

            var restorane = validateRestorane.Value;

            return restorane;

        });

        return convertedEntitys.ToList();

    }

    public async Task<Result<Restorane>> GetById(Guid restoraneId)
    {
        var restorane = await _context
            .Restoranes
            .AsNoTracking()
            .Include(ex => ex.Orders)
            .Include(ex => ex.Workers)
            .SingleAsync(ex => ex.Id == restoraneId);

        var workers = restorane.Workers.Select(
            ex =>
            {
                var validateName = FullName.Create(ex.FirstName, ex.MiddleName, ex.LastName);

                if (validateName.IsFailure)
                {
                    return null;
                }

                var name = validateName.Value;
                
                var worker = Cooker.Create(ex.Id, name, null);

                return worker;
            }
        );

    }

    public async Task<Result> SaveChanges(Restorane restorane)
    {
        try
        {
            await _context
                .Restoranes
                .Where(ex => ex.Id == restorane.Id)
                .ExecuteUpdateAsync(
                    ex =>
                        ex.SetProperty(props => props.StartWorkingTime, restorane.WorkTime.StartOrderingTime)
                            .SetProperty(props => props.StopWorkingTime, restorane.WorkTime.StopOrderingTime)
                            .SetProperty(props => props.Address, restorane.Address.FullAddress)
                );
            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }
}