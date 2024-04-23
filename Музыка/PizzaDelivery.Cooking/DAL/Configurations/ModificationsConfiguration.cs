using DAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ModificationsConfiguration : IEntityTypeConfiguration<ModificationsEntitys>
{
    public void Configure(EntityTypeBuilder<ModificationsEntitys> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .Property(ex => ex.Name)
            .IsRequired();

        builder
            .HasMany(ex => ex.UsedInCookingOrders)
            .WithOne(ex => ex.ModificationEntitys)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ModificationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(ex => ex.ContainingIngridients)
            .WithOne(ex => ex.ModificationEntitys)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.ModificationId)
            .OnDelete(DeleteBehavior.SetNull);

    }
}