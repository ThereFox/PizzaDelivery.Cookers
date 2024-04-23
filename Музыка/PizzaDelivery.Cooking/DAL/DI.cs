using App.Interfaces;
using DAL.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DI
{
    public static IServiceCollection AddDAL(this IServiceCollection services, Action<DbContextOptionsBuilder> DBconfiguration)
    {
        services.AddDbContext<ApplicationDBContext>(DBconfiguration, ServiceLifetime.Transient);

        services.AddTransient<IProductTechnologyCardStore, ProductTechnologyCardStore>();
        services.AddTransient<ICookersStore, CookersStore>();
        services.AddTransient<IIngridientsStore, IngridientsStore>();
        services.AddTransient<IOrderStore, OrdersStore>();
        services.AddTransient<IProductStore, ProductsStore>();
        services.AddTransient<IRestoraneStore, RestoranesStore>();

        return services;
    }
}