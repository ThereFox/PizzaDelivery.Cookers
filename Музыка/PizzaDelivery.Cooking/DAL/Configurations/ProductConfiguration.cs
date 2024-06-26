using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<ProductsTechCardDBEntity>
{
    public void Configure(EntityTypeBuilder<ProductsTechCardDBEntity> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Name)
            .IsRequired();

        builder.HasMany(ex => ex.Cookings)
            .WithOne(ex => ex.BaseProductTechCardDbEntity)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.BaseProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(ex => ex.IngridientContaining)
            .WithOne(ex => ex.ProductTechCardDbEntity)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ProductId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}