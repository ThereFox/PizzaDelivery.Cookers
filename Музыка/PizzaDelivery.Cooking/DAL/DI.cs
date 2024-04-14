using App.Interfaces;
using DAL.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DI
{
    public static IServiceCollection AddDAL(this IServiceCollection services, Action<DbContextOptionsBuilder> DBconfiguration)
    {
        services.AddDbContext<ApplicationDBContext>(DBconfiguration, ServiceLifetime.Singleton);

        services.AddSingleton<IContainingStore, ContainingStores>();
        services.AddSingleton<ICookersStore, CookersStore>();
        services.AddSingleton<IIngridientsStore, IngridientsStore>();
        services.AddSingleton<IOrderStore, OrdersStore>();
        services.AddSingleton<IProductStore, ProductsStore>();
        services.AddSingleton<IRestoraneStore, RestoranesStore>();

        return services;
    }
}