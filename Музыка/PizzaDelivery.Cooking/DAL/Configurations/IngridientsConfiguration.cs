using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class IngridientsConfiguration : IEntityTypeConfiguration<IngridientsEntity>
{
    public void Configure(EntityTypeBuilder<IngridientsEntity> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Name);

        builder
            .HasMany(ex => ex.ContainingInModifications)
            .WithOne(ex => ex.IngridientEntity)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.IngridientId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(ex => ex.ContainingInProducts)
            .WithOne(ex => ex.IngridientEntity)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.IngridientId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(ex => ex.StocksInRestorans)
            .WithOne(ex => ex.Ingridient)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.IngridientId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}