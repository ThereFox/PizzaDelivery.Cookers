using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace App.Interfaces;

public interface IRestoraneStore
{
    public Task<List<Restorane>> GetAllByPage(int page, int pageSize);
    public Task<Result<Restorane>> GetById(Guid restoraneId);

    public Task<Result> Create(Restorane restorane);
    public Task<Result> Delete(Guid id);
    public Task<Result> SaveChanges(Restorane restorane);
}