using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace DAL.Stores;

public class CookersStore : ICookersStore
{
    public Task<Result<Cooker>> GetById(Guid id)
    {
        throw new NotImplementedException();
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

    public Task<Result> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}