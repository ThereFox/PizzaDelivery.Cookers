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
    
    public async Task<List<Restorane>> GetAll()
    {
        return await _context.Restoranes.ToListAsync();
    }

    public Task<Result<Restorane>> GetById(Guid restoraneId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> GetCurrentOrders(Guid restoraneId)
    {
        throw new NotImplementedException();
    }

    public Task<RestoraneStocks> GetMiddleIngridientLoosesByDay(Guid restoraneId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(Restorane restorane)
    {
        throw new NotImplementedException();
    }
}