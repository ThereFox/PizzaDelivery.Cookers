using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces;

public interface IOrderStore
{
    public Task<List<Order>> GetAllByPage(int page, int pageSize);
    public Task<Result<Order>> GetById(Guid id);
    public Task<Result<Order>> GetByCode(string code);
    
    public Task<List<Order>> GetInCookByPage(int page, int pageSize);
    public Task<List<Order>> GetCurrentOrdersInRestoraneByPage(Guid restoraneId, int page, int pageSize);
    
    public Task<Result> SaveChanges(Order order);
    public Task<Result> Create(Order order);
    public Task<Result> Delete(Guid id);
}