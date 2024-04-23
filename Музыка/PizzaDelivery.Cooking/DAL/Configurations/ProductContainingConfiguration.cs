using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ProductContainingConfiguration : IEntityTypeConfiguration<ProductsContainingsEntitys>
{
    public void Configure(EntityTypeBuilder<ProductsContainingsEntitys> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Weight)
            .IsRequired();

        builder
            .HasOne(ex => ex.ProductTechCardDbEntity)
            .WithMany(ex => ex.IngridientContaining)
            .HasForeignKey(ex => ex.ProductId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(ex => ex.IngridientEntity)
            .WithMany(ex => ex.ContainingInProducts)
            .HasForeignKey(ex => ex.IngridientId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.NoAction);

    }
}