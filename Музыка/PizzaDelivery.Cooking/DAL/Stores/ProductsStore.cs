using App.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.Filtrs;

namespace DAL.Stores;

public class ProductsStore : IProductStore
{
    private readonly ApplicationDBContext _context;

    public ProductsStore(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<Result<Product>> GetById(Guid id)
    {
        var product = await _context
            .OrderedProducts
            .AsNoTracking()
            .Include(ex => ex.BaseProductTechCardDbEntity)
            .FirstAsync(ex => ex.Id == id);

        var validateProductTechnologyCard = ProductTechnologyCard.Create(product.Id)
        
        var convertedProduct = Product.Create(product.Id, product,);
        
        return Result.Failure<Product>("not realised");
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