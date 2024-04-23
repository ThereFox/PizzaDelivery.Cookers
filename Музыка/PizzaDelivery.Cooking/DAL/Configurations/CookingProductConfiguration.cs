using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CookingProductConfiguration : IEntityTypeConfiguration<CookingProductsEntity>
{
    public void Configure(EntityTypeBuilder<CookingProductsEntity> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.State);
        
        builder.HasOne(ex => ex.CookerEntity)
            .WithMany(ex => ex.CookedProducts)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.CookerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(ex => ex.OrderEntitys)
            .WithMany(ex => ex.Elements)
            .HasForeignKey(ex => ex.OrderId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(ex => ex.Modifications)
            .WithOne(ex => ex.ProductEntity)
            .HasForeignKey(ex => ex.CookingProductId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}