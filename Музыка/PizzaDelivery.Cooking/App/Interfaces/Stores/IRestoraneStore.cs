using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace App.Interfaces;

public interface IRestoraneStore
{
    public Task<List<Restorane>> GetAll();
    public Task<Result<Restorane>> GetById(Guid restoraneId);
    public Task<List<Order>> GetCurrentOrders(Guid restoraneId);

    public Task<RestoraneStocks> GetMiddleIngridientLoosesByDay(Guid restoraneId);
    
    public Task<Result> SaveChanges(Restorane restorane);
}