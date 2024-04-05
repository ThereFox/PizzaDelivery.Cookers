using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces;

public interface IIngridientsStore
{
    public Task<List<Ingridient>> GetAll();
    public Task<Result<Ingridient>> GetById(Guid id);
    public Task<List<Ingridient>> GetNMostUsed(int n);
    public Task<List<Ingridient>> GetNLowUsed(int n);
    public Task<Result> Create(Ingridient ingridient);
    public Task<Result> Delete(Guid id);
    public Task<Result> SaveChanges(Ingridient ingridient);
}