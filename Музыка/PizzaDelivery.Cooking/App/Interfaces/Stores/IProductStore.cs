using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.Filtrs;

namespace App.Interfaces;

public interface IProductStore
{
    public Task<Result<Product>> GetById(Guid id);
    
    public Task<List<Product>> GetWithFiltr(ProductFiltr filtr);
    public Task<List<Product>> GetMostCooking();
    
    public Result SaveChanges(Product updated);
}