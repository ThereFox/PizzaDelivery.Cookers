using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces;

public interface IIngridientsStore
{
    public Task<List<Ingridient>> GetAllByPage(int page, int pageSize);
    public Task<Result<Ingridient>> GetById(Guid id);
    public Task<Result> Create(Ingridient ingridient);
    public Task<Result> Delete(Guid id);
    public Task<Result> SaveChanges(Ingridient ingridient);
}