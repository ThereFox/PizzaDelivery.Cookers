using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces;

public interface IOrderStore
{
    public Task<Result<Order>> GetById(Guid id);
    public Task<Result<Order>> GetByCode(string code);
    public Task<List<Order>> GetInCook();

    public Task<Result> SaveChanges(Order order);
}