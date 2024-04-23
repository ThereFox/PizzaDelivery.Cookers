using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.Filtrs;

namespace App.Interfaces;

public interface IProductStore
{
    public Task<Result<Product>> GetById(Guid id);
    public Task<List<Product>> GetWithFiltrByPage(ProductFiltr filtr, int page, int pageSize);

    public Task<Result> Delete(Guid id);
    public Task<Result> SaveChanges(Product updated);
}