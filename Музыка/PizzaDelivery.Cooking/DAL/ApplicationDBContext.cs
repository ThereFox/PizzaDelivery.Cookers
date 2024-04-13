using DAL.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDBContext : DbContext
{
    public DbSet<Cookers> Cookers { get; private set; }
    public DbSet<Ingridients> Ingridients { get; private set; }
    public DbSet<Modifications> Modifications { get; private set; }
    public DbSet<Orders> Orders { get; private set; }
    public DbSet<Products> OrderedProducts { get; private set; }
    public DbSet<Products> BaseProducts { get; private set; }
    
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> DBconfiguration) : base(DBconfiguration)
    {
        this.Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }
}