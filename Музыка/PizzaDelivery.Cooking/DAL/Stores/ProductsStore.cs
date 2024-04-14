using App.Interfaces;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.Filtrs;

namespace DAL.Stores;

public class ProductsStore : IProductStore
{
    public Task<Result<Product>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetWithFiltr(ProductFiltr filtr)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetMostCooking()
    {
        throw new NotImplementedException();
    }

    public Result SaveChanges(Product updated)
    {
        throw new NotImplementedException();
    }
}