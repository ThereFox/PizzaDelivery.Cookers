using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace DAL.Stores;

public class OrdersStore : IOrderStore
{
    public Task<Result<Order>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Order>> GetByCode(string code)
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> GetInCook()
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(Order order)
    {
        throw new NotImplementedException();
    }
}