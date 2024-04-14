using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace DAL.Stores;

public class ContainingStores : IContainingStore
{
    public Task<Result> CreateProductContaining(ProductInfo productInfo)
    {
        throw new NotImplementedException();
    }

    public Task<Result> CreateModificationContaining(ModificationInfo modificationInfo)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ProductInfo>> GetProductById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ModificationInfo>> GetModificationById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(ProductInfo productInfo)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(ModificationInfo productInfo)
    {
        throw new NotImplementedException();
    }
}