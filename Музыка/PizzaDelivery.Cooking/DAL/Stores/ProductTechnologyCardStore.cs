using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace DAL.Stores;

public class ProductTechnologyCardStore : IProductTechnologyCardStore
{
    public Task<Result> CreateProductContaining(ProductTechnologyCard productTechnologyCard)
    {
        var 
    }

    public Task<Result> CreateModificationContaining(ModificationTechologyCard modificationTechologyCard)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ProductTechnologyCard>> GetProductById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ModificationTechologyCard>> GetModificationById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(ProductTechnologyCard productTechnologyCard)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(ModificationTechologyCard product)
    {
        throw new NotImplementedException();
    }
}