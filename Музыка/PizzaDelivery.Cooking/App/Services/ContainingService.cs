using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace App.Services;

public class ContainingService
{
    private readonly IContainingStore _store;

    public ContainingService(IContainingStore containingStore)
    {
        _store = containingStore;
    }
    
    public async Task<Result> CreateProductContaining(ProductInfo containing)
    {
        return await _store.CreateProductContaining(containing);
    }
    public async Task<Result> CreateModificationContaining(ModificationInfo containing)
    {
        return await _store.CreateModificationContaining(containing);
    }
    public async Task<Result> UpdateProductContaining(Guid productId, ProductContaining containing)
    {
        var getproductContainingResult = await _store.GetProductById(productId);

        if (getproductContainingResult.IsFailure)
        {
            return getproductContainingResult;
        }

        var productContaining = getproductContainingResult.Value;

        var updateContainingResult = productContaining.UpdateContaining(containing);

        if (updateContainingResult.IsFailure)
        {
            return updateContainingResult;
        }

        return await _store.SaveChanges(productContaining);
    }
    public async Task<Result> DeleteProductContaining(Guid productId, ProductContaining containing)
    {
        var getproductContainingResult = await _store.GetProductById(productId);

        if (getproductContainingResult.IsFailure)
        {
            return getproductContainingResult;
        }

        var productContaining = getproductContainingResult.Value;

        var updateContainingResult = productContaining.RemoveContaining(containing);

        if (updateContainingResult.IsFailure)
        {
            return updateContainingResult;
        }

        return await _store.SaveChanges(productContaining);
    }
    public async Task<Result> UpdateModificationContaining(Guid productId, ProductContaining containing)
    {
        var getproductContainingResult = await _store.GetModificationById(productId);

        if (getproductContainingResult.IsFailure)
        {
            return getproductContainingResult;
        }

        var modificationContaining = getproductContainingResult.Value;

        var updateContainingResult = modificationContaining.UpdateContaining(containing);

        if (updateContainingResult.IsFailure)
        {
            return updateContainingResult;
        }

        return await _store.SaveChanges(modificationContaining);
    }
    public async Task<Result> DeleteModificationContaining(Guid productId, ProductContaining containing)
    {
        var getProductContainingResult = await _store.GetModificationById(productId);

        if (getProductContainingResult.IsFailure)
        {
            return getProductContainingResult;
        }

        var modificationContaining = getProductContainingResult.Value;

        var updateContainingResult = modificationContaining.RemoveContaining(containing);

        if (updateContainingResult.IsFailure)
        {
            return updateContainingResult;
        }

        return await _store.SaveChanges(modificationContaining);
    }
    
}