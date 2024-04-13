using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ModificationContainingConfiguration : IEntityTypeConfiguration<ModificationContainings>
{
    public void Configure(EntityTypeBuilder<ModificationContainings> builder)
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
            .HasOne(ex => ex.Modification)
            .WithMany(ex => ex.ContainingIngridients)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ModificationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(ex => ex.Ingridient)
            .WithMany(ex => ex.ContainingInModifications)
            .HasForeignKey(ex => ex.IngridientId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.SetNull);

    }
}