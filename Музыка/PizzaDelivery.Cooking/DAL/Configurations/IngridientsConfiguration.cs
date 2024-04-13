using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class IngridientsConfiguration : IEntityTypeConfiguration<Ingridients>
{
    public void Configure(EntityTypeBuilder<Ingridients> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Name);

        builder
            .HasMany(ex => ex.ContainingInModifications)
            .WithOne(ex => ex.Ingridient)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.IngridientId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(ex => ex.ContainingInProducts)
            .WithOne(ex => ex.Ingridient)
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