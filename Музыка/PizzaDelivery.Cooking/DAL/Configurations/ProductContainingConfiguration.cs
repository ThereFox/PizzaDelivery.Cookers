using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ProductContainingConfiguration : IEntityTypeConfiguration<ProductsContainings>
{
    public void Configure(EntityTypeBuilder<ProductsContainings> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Weight)
            .IsRequired();

        builder
            .HasOne(ex => ex.Product)
            .WithMany(ex => ex.IngridientContaining)
            .HasForeignKey(ex => ex.ProductId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(ex => ex.Ingridient)
            .WithMany(ex => ex.ContainingInProducts)
            .HasForeignKey(ex => ex.IngridientId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.NoAction);

    }
}