using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace DAL.Stores;

public class IngridientsStore : IIngridientsStore
{
    public Task<List<Ingridient>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Ingridient>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Ingridient>> GetNMostUsed(int n)
    {
        throw new NotImplementedException();
    }

    public Task<List<Ingridient>> GetNLowUsed(int n)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Create(Ingridient ingridient)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(Ingridient ingridient)
    {
        throw new NotImplementedException();
    }
}