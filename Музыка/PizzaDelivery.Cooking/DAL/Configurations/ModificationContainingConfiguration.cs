using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ModificationContainingConfiguration : IEntityTypeConfiguration<ModificationContainingsEntitys>
{
    public void Configure(EntityTypeBuilder<ModificationContainingsEntitys> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Id)
            .IsRequired();

        builder
            .Property(ex => ex.ContainingWeight)
            .IsRequired();

        builder
            .HasOne(ex => ex.ModificationEntitys)
            .WithMany(ex => ex.ContainingIngridients)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ModificationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(ex => ex.IngridientEntity)
            .WithMany(ex => ex.ContainingInModifications)
            .HasForeignKey(ex => ex.IngridientId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.SetNull);

    }
}