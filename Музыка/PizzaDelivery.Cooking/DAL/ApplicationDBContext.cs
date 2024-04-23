using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace DAL;

public class ApplicationDBContext : DbContext
{
    public DbSet<RestoransDBEntity> Restoranes { get; private set; }
    public DbSet<CookersEntity> Cookers { get; private set; }
    public DbSet<IngridientsEntity> Ingridients { get; private set; }
    public DbSet<ModificationsEntitys> Modifications { get; private set; }
    public DbSet<OrdersEntitys> Orders { get; private set; }
    public DbSet<CookingProductsEntity> OrderedProducts { get; private set; }
    public DbSet<ProductsTechCardDBEntity> BaseProducts { get; private set; }
    
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> DBconfiguration) : base(DBconfiguration)
    {
        this.Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }
}