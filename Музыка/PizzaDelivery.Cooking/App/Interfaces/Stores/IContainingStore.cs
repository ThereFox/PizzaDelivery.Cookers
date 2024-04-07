using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces;

public interface IContainingStore
{
    public Task<Result> CreateProductContaining(ProductInfo productInfo);
    public Task<Result> CreateModificationContaining(ModificationInfo modificationInfo);
    
    public Task<Result<ProductInfo>> GetProductById(Guid id);
    public Task<Result<ModificationInfo>> GetModificationById(Guid id);

    public Task<Result> SaveChanges(ProductInfo productInfo);
    public Task<Result> SaveChanges(ModificationInfo productInfo);

}