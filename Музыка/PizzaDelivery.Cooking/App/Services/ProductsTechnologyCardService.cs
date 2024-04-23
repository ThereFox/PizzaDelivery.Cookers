using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace App.Services;

public class ProductsTechnologyCardService
{
    private readonly IProductTechnologyCardStore _store;

    public ProductsTechnologyCardService(IProductTechnologyCardStore productTechnologyCardStore)
    {
        _store = productTechnologyCardStore;
    }
    
    public async Task<Result> CreateProductContaining(ProductTechnologyCard containing)
    {
        return await _store.Create(containing);
    }
    public async Task<Result> UpdateProductContaining(Guid productId, ProductContaining containing)
    {
        var getproductContainingResult = await _store.GetById(productId);

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
        var getproductContainingResult = await _store.GetById(productId);

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
    
    
}