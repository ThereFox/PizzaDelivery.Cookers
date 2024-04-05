using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.Filtrs;

namespace App.Interfaces;

public interface ICookersStore
{
    public Task<Result<Cooker>> GetById(Guid id);
    public Task<List<Cooker>> GetNMostBusy(int n);
    public Task<Result> SaveChanges(Cooker cooker);

    public Task<Result> Create(Cooker cooker);
    public Task<Result> Delete(Guid id);

}