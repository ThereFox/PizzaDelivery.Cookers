using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.Filtrs;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace App.Services;

public class ProductService
{
    private readonly IProductStore _productStore;
    private readonly IOrderStore _orderStore;
    private readonly IRestoraneStore _restoraneStore;
    
    public async Task<Result<List<Product>>> GetActiveInRestorane(Guid restoraneId)
    {
        var restoraneById = await _restoraneStore.GetById(restoraneId);

        if (restoraneById.IsFailure)
        {
            return Result.Failure<List<Product>>("dont have restorane with this id");
        }
        
        var orders = await _restoraneStore.GetCurrentOrders(restoraneId);

        if (orders.Count == 0)
        {
            return Result.Success<List<Product>>(new List<Product>());
        }
        
        var activeProductsInRestorant =
            orders.SelectMany(ex => ex.Composition.Where(ex => ex.State == ProductCookState.InCook))
                .ToList();

        return Result.Success<List<Product>>(activeProductsInRestorant);

    }

    public async Task<Result<Product>> GetById(Guid id)
    {
       return await _productStore.GetById(id);
    }

    public async Task<Result> ChangeCreater(Guid id, Cooker cooker)
    {
        var getProductResult = await _productStore.GetById(id);

        if (getProductResult.IsFailure)
        {
            return getProductResult;
        }
        
        var product = getProductResult.Value;

        var changeResult = product.SetCooker(cooker);

        if (changeResult.IsFailure)
        {
            return changeResult;
        }

        return _productStore.SaveChanges(product);
    }

    public async Task<Result> UpdateCookState(Guid id, ProductCookState state)
    {
        var getProductResult = await _productStore.GetById(id);

        if (getProductResult.IsFailure)
        {
            return getProductResult;
        }
        
        var product = getProductResult.Value;

        var changeResult = product.ChangeState(state);

        if (changeResult.IsFailure)
        {
            return changeResult;
        }

        return _productStore.SaveChanges(product);
    }

    public async Task<List<Product>> GetNMostOrdering()
    {
        var products = await _productStore.GetMostCooking();
        return products;
    }

    public async Task<List<Product>> GetCurrent()
    {
        var filtr = new ProductFiltr(null, [ProductCookState.InCook]);

        var getCurrent = await _productStore.GetWithFiltr(filtr);

        return getCurrent;
    }
}