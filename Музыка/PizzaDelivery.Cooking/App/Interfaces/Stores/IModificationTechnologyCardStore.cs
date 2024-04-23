using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces;

public interface IModificationTechnologyCardStore
{
    public Task<List<ModificationTechologyCard>> GetAllByPage(int page, int pageSize);
    public Task<Result<ModificationTechologyCard>> GetById(Guid id);
    
    public Task<Result> Create(ModificationTechologyCard entity);
    public Task<Result> Delete(Guid id);
    public Task<Result> SaveChanges(ModificationTechologyCard product);
}