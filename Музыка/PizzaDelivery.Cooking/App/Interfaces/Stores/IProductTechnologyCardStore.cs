using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces;

public interface IProductTechnologyCardStore
{
    public Task<List<ProductTechnologyCard>> GetAllByPage(int page, int pageSize);
    public Task<Result<ProductTechnologyCard>> GetById(Guid id);
    
    public Task<Result> Create(ProductTechnologyCard productTechnologyCard);
    public Task<Result> Delete(Guid id);
    public Task<Result> SaveChanges(ProductTechnologyCard productTechnologyCard);

}